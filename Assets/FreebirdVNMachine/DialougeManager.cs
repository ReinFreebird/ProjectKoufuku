using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using DG.Tweening;

[System.Serializable]
public class spriteArrayList{
	public Sprite[] spritesChara;

	public Sprite getSprites(int index){
		return spritesChara[index];
	}
}
public class DialougeManager:MonoBehaviour{

	//DialougeManager includes change background,
	//nextMessage to continue Conversation
	//an other

	//List and arrays
	List<dialougeLine> lines=new List<dialougeLine>();
	public Image[] sprites;
	Sprite[][] spriteContainer;
	GameObject[] selectionButtons;


	//Objects in canvas and others
	public GameObject dialougeWindow;
	public GameObject textBox,charName,background;
	public GameObject charaWindow, textWindow;
	public Sprite[] charaWindowSprite;
	public GameObject selectionPanel;
	public GameObject selectionButtonPrefab;
	public GameObject pressObject;
	public AudioSource soundclip;
	public AudioClip[] clip;
	public AudioSource BGM;
	public AudioClip[] backgroundMusic;
	public Sprite[] backgrounds; 
	Dialouge diaFile;			//Dialouge acts as line parser
	Sprite previousSprite;
	string previousCharName;
	Material dotWeenMat;
	public Button continueButton;
	//public Text txtBoxTx, charNameTx;
	public SceneManagerClassv2 sceneManager;
	public GameObject displayTint;

	//Atributes
	public string dialougeFileName; //for debugging purpose, file name are public. when done fileName depends on choice
	int lineCounter=0;
	public float messageSpeed;//Above 0
	bool messageScrolling=false;
	bool messageScrolling2=false;
	//bool spriteFading=false;
	List<string> loadedFileName= new List<string>();
	List<Dialouge>loadedDialougeFile=new List<Dialouge>();
	public Sprite[] backgroundArray;


	//public object for Android Build
	public spriteArrayList[] charaSpritesArray;
	public string[] charaNames;
	void Awake(){
		//make new Dialouge object. File reading are done in Dialouge class
		//LoadDialouge(dialougeFileName);
		//check all file line
		//for (int i = 0; i < lines.Count; i++) {
		//	Debug.Log (postAllAttribute(i));
		//}
		//check if text box and char name is text
			//nvm
		//get charaSprite from Dialouge Class
			}
	void update(){
	}
	void Start(){
		
	}
	public void startDemo(){
		if (PlayerPrefs.GetInt ("SFX",1) == 0) {
			soundclip.mute = true;
		} else {
			soundclip.mute = false;
		}
		if (PlayerPrefs.GetInt ("BGM", 1) == 0) {
			BGM.mute = true;
		} else {
			BGM.mute = false;
		}
		messageSpeed = PlayerPrefs.GetFloat ("Speed", 5f);
		//sprites [0].gameObject.SetActive (false);
		textBox.gameObject.GetComponent<Text> ().text = "";
		charName.gameObject.GetComponent<Text> ().text = "";
		if (PlayerPrefs.HasKey("dialougeFile")) {	//load dialouge data if prefs is true
			dialougeFileName=PlayerPrefs.GetString("dialougeFile");
			lineCounter= PlayerPrefs.GetInt("lineCounter");	
		}else{
			dialougeFileName="debug";
			lineCounter=0;
		}
		PlayerPrefs.DeleteKey ("dialougeFile");
		PlayerPrefs.DeleteKey ("lineCounter");
		LoadDialouge(dialougeFileName);
		spriteContainer=diaFile.getCharaSprite();
		//if (Application.platform == RuntimePlatform.Android) {
		//	charName.GetComponent<Text> ().text = linesJson [33].id;
		//	textBox.GetComponent<Text> ().text = "you are playing in android mode";
		//}
		nextMessage ();
	}
	public void nextMessage(){
		Debug.Log(lineCounter);
		if (!messageScrolling) { 		//if message is not changing
			messageScrolling = true;
			if (Application.platform == RuntimePlatform.Android) {//If running on Android
			}else {			//Not running in android
				
				if (lineCounter < lines.Count) {
					//Check if line is a function or not
					if (!lines [lineCounter].isFunction ()) { //Not a function


						if (lines [lineCounter].getLine () == null) {
							
								charName.gameObject.GetComponent<Text>().text = lines [lineCounter].getCharaName();
								lineCounter++;
								messageScrolling=false;
								messageScrolling2=false;
								nextMessage();
						} else {
							dialougeWindow.gameObject.SetActive(true);
							string lineContainer = lines [lineCounter].getLine ();
							textBox.gameObject.GetComponent<Text> ().text="";
							if (!messageScrolling2) {
							StartCoroutine ("nextChar", lineContainer);
							//			Debug.Log (lineCounter);
							lineCounter++;
							}
						
						}
						//Per char text
						
						//lineContainer=textBox.gameObject.GetComponent<Text> ().text;
						//line =lineContainer +r.ReadLine ();
					} else {	
						//Debug.Log ("is function");	//Line is function
						string [] param;
						switch (lines [lineCounter].getFunctionName ()) {
						case "Play_Music":
							playBGM (int.Parse(lines [lineCounter].getFunctionParameter ()));
							break;
						case "Skip":
							lineCounter++;
							//Debug.Log ("skip called");
							messageScrolling = false;
							break;
						case "Play_Clip":
							StartCoroutine( playClipDialouge (int.Parse(lines [lineCounter].getFunctionParameter ())));
							lineCounter++;
							messageScrolling = false;
							break;
						case "Play_Clip_No_Wait":
							StartCoroutine( playClipDialougeNoWait (int.Parse(lines [lineCounter].getFunctionParameter ())));
							lineCounter++;
							messageScrolling = false;
							break;
						case "Selection":
							lineCounter++;
							instantiateSelection (int.Parse(lines [lineCounter - 1].getFunctionParameter ()));
							break;
						case "Jump_to_Line":
							LoadDialouge (int.Parse(lines [lineCounter].getFunctionParameter ()));
							break;
						case "Fade_BG":
							StartCoroutine (fadeBG (int.Parse(lines [lineCounter].getFunctionParameter ())));
							break;
						case "Tint_Sprite":
							param = lines [lineCounter].getFunctionParameter().Split(',');
							Debug.Log(param[0]+' '+param[1]);
							StartCoroutine(tintSprite(int.Parse(param[0]),param[1],param[2]));
							break;
						case "Transation_Sprite_X_Position":
							param = lines [lineCounter].getFunctionParameter().Split(',');
							Debug.Log(param[0]+' '+param[1]);
							StartCoroutine(transationSpriteXPosition(int.Parse(param[0]),float.Parse(param[1]),param[2]));
							break;
						case "Clear_Box":
							StartCoroutine(clearBox());
							break;
						case "Fade_In_From_Black":
							param = lines [lineCounter].getFunctionParameter().Split(',');
							StartCoroutine(fadeInFromBlack(float.Parse(param[0]),param[1]));
							break;
						case "Fade_Out_To_Black":
							param = lines [lineCounter].getFunctionParameter().Split(',');
							StartCoroutine(fadeOutToBlack(float.Parse(param[0]),param[1]));
							break;
						case "Close_Dialouge_Window":
							param = lines [lineCounter].getFunctionParameter().Split(',');
							StartCoroutine(closeDialougeWindow(param[0]));
							break;
						case "Change_Scene_With_Pref":
							changeSceneForReturn (int.Parse(lines [lineCounter].getFunctionParameter ()));
							break;
						case "Change_Scene_No_Pref":
							changeSceneNoReturn (int.Parse(lines [lineCounter].getFunctionParameter ()));
							break;
						default :
							switch (lines [lineCounter].getLineType()) {
							case"CS":
								setPrefString (lines [lineCounter].getFunctionName (), lines [lineCounter].getFunctionParameter ());
								break;
							case"CI":
								setPrefInt (lines [lineCounter].getFunctionName (), int.Parse(lines [lineCounter].getFunctionParameter ()));
								break;
							case"CC":
								enableCharaChapter(lines [lineCounter].getFunctionName (), int.Parse(lines [lineCounter].getFunctionParameter ()));
								break;
							case"CCG":
								enableCGReward(lines [lineCounter].getFunctionName (), int.Parse(lines [lineCounter].getFunctionParameter ()));
								break;
							case"CB"://Change Bool
								VNPrefs.SetBool (lines [lineCounter].getFunctionName (), true);
								lineCounter++;
								StartCoroutine (nextWithWaitSpriteAnimator ());
								messageScrolling = false;
								break;
							}
							break;
						}
					}
				} else {
				//do nothing
				
				}
			}
		} else {			//if message is scrolling, skip text to end
			if (Application.platform == RuntimePlatform.Android) {//if running in android
				
			} else {
				if (!lines [lineCounter - 1].isFunction ()) {	//only rum if not a function
					StopCoroutine ("nextChar");
					textBox.gameObject.GetComponent<Text> ().text = "";
					textBox.gameObject.GetComponent<Text> ().text = lines [lineCounter - 1].getLine ();
					//StartCoroutine(haltContinueButton(0.25f));
					messageScrolling = false;
					messageScrolling2 = false;
				}
			}
		}
	}

	IEnumerator nextChar(string line){
		//Debug.Log("nextChar is called");
		messageScrolling2=true;
		for (int i = 0; i < line.Length; i++) {
			yield return new WaitForSeconds (0.1f/messageSpeed);
			//Debug.Log(line[i]);
				textBox.gameObject.GetComponent<Text> ().text += line [i];

		}
		messageScrolling2=false;
		messageScrolling = false;

	}
	IEnumerator clearBox(){

		textBox.gameObject.GetComponent<Text> ().text ="";
		charName.gameObject.GetComponent<Text> ().text ="";
		yield return null;
		lineCounter++;
		messageScrolling2=false;
		messageScrolling = false;
		
		nextMessage();

	}
	IEnumerator changeSprite(int x,int y,int z){
		//x = chara Name
		//y = sprite ID(poses)
		//z =sprite to be changed in canvas
		if (!spriteContainer [x] [y].Equals (previousSprite)) {	//change sprite if previous sprite is different 
		

			//using animator
			if (previousCharName!= lines[lineCounter].charaName&&previousCharName!="NULL") {
				sprites [z].gameObject.SetActive (false);
				sprites[z].gameObject.GetComponent<Animator>().SetBool("Visable",false);
				//sprites [z].sprite = null;
				sprites [z].gameObject.SetActive (true);
				yield return new WaitUntil (() => sprites [z].gameObject.GetComponent<Animator> ().isInitialized);
				yield return new WaitForSeconds(0.001f);
				//Debug.Log ("lol");
			}
			sprites [z].sprite = spriteContainer [x] [y];
			sprites[z].gameObject.GetComponent<Animator>().SetBool("Visable",true);
			//sprites [z].gameObject.SetActive (false);
			yield return new WaitForSeconds(0.001f);
			sprites [z].gameObject.SetActive (true);
			yield return new WaitUntil (() => sprites [z].gameObject.GetComponent<Animator> ().isInitialized);
			previousSprite = sprites [z].sprite;
			//spriteFading = false;
		}
	}
	IEnumerator changeSpriteAndroid(string charaName,int spriteIndex, int spriteContainerIndex){
		continueButton.interactable = false;
		Sprite newSprite;
		spriteArrayList temp;
		int index=0;
		for (int i = 0; i < charaNames.Length; i++) {
			if(charaName==charaNames[i]){
				break;
			}
			index++;
		}
		temp = charaSpritesArray[index];
		newSprite = temp.getSprites (spriteIndex);
		if (previousCharName != charaName) {
		//	if (previousCharName != "NULL") {
				sprites [spriteContainerIndex].gameObject.SetActive (false);

				sprites [spriteContainerIndex].gameObject.GetComponent<Animator> ().SetBool ("Visable", false);
				//sprites [z].sprite = null;
				sprites [spriteContainerIndex].gameObject.SetActive (true);
				yield return new WaitUntil (() => sprites [spriteContainerIndex].gameObject.GetComponent<Animator> ().isInitialized);
				yield return new WaitForSeconds (0.001f);
				//Debug.Log ("lol");
		//	} else {
			
			
		//	}
		
		}
		if (!newSprite.Equals (previousSprite)) {	//change sprite if previous sprite is different 
			sprites [spriteContainerIndex].sprite = newSprite;
			//sprites[spriteContainerIndex].gameObject.GetComponent<Animator>().SetBool("Visable",true);
			//sprites [spriteContainerIndex].gameObject.SetActive (false);
			//yield return new WaitForSeconds(0.001f);
			//sprites [spriteContainerIndex].gameObject.SetActive (true);
			//yield return new WaitUntil (() => sprites [spriteContainerIndex].gameObject.GetComponent<Animator> ().isInitialized);
			previousSprite = sprites [spriteContainerIndex].sprite;
			//spriteFading = false;

		}

		yield return new WaitForSeconds(0.1f);
		continueButton.interactable = true;
	}
	IEnumerator spriteChangeToNull(int z){
		continueButton.interactable = false;
		if (sprites [z].sprite == null) {
			//do nothing if sprite is already null
		} else {
			//using animation
			//spriteFading = true;
			//sprites [z].gameObject.SetActive (true);
			//sprites [z].GetComponent<Animation> ().Play ("spriteFadeOut");
			//yield return new WaitForSeconds (0.75f);
			//sprites [z].sprite = null;
			//previousSprite = sprites [z].sprite;
			//sprites [z].gameObject.SetActive (false);
			//spriteFading = false;
			//using animator
			sprites [z].gameObject.SetActive (true);
			sprites[z].gameObject.GetComponent<Animator>().SetBool("Visable",false);
			yield return new WaitUntil (() => sprites [z].gameObject.GetComponent<Animator> ().isInitialized);
			yield return new WaitForSeconds(1f);
			sprites [z].sprite = null;
			previousSprite = sprites [z].sprite;
			//sprites [z].gameObject.SetActive (false);
		}
		continueButton.interactable = true;
	}
	GameObject instantiateButton(){
		GameObject temp;
		temp = Instantiate (selectionButtonPrefab,selectionPanel.transform) as GameObject;
		//temp.transform.parent = selectionPanel.transform;
		Vector3 posTemp = temp.transform.position;
		temp.transform.localPosition=new Vector3 (posTemp.x, posTemp.y, 0);
		temp.transform.DOScale (1, 0f);
		return temp;
		//temp = Instantiate (selectionButtonPrefab) as GameObject;
		//temp.transform.SetParent (selectionPanel.transform);
		//posTemp = temp.transform.position;
		//temp.transform.position = new Vector3 (posTemp.x, posTemp.y, 0);
		//temp = Instantiate (selectionButtonPrefab) as GameObject;
		//temp.transform.Setarent (selectionPanel.transform);
		//posTemp = temp.transform.position;
		//temp.transform.position = new Vector3 (posTemp.x, posTemp.y, 0);
	}
	string postAllAttribute(int x){
		return lines [x].getCharaName () + " " + lines [x].getLine () + " " + lines [x].getSpriteIndex ().ToString ();
	}
	void Update(){
	}
	public void tryReadFile(){
	
	}
	void LoadDialouge(string fileName){ //Normal loadDialouge
		//lineCounter = 0;
		diaFile = new Dialouge (fileName); //First dialougeFile to be read.
		if (Application.platform == RuntimePlatform.Android) {//If running on android
			
		} else {
			lines = diaFile.getDialougeLine();
		}
		//if (!checkLoadedFile (fileName)) {	//If new file to be loaded //No longer needed 03 May 2017
		//	loadedDialougeFile.Add (diaFile);
		//}
	}
	void LoadDialouge (int line){	//Jump to line on a same file
		lineCounter = line - 1;
		messageScrolling = false;
		StartCoroutine (nextWithWaitSpriteAnimator ());
	}
	void selectionChoice(int line){	//Jump to line on a same file by selection
		charaWindow.SetActive(true);
		lineCounter = line-1;
		//Debug.Log (lineCounter);
		GameObject temp;
		foreach (var item in selectionPanel.GetComponentsInChildren<Button>()) {
			temp = item.gameObject;
			Destroy (temp);
		}
		pressObject.SetActive (true);
		messageScrolling = false;
		playClip (0);
		StartCoroutine (nextWithWaitSpriteAnimator ());
	}
	void playBGM(int x){			// function read in txt file
		//continueButton.interactable=false;
		if (x >= 0) {
			BGM.clip = backgroundMusic [x];
			StartCoroutine (fadeBGM (true));
		} else {
		//	Debug.Log ("stopCalled");
			StartCoroutine (fadeBGM (false));

		}
		lineCounter++;
		messageScrolling = false;
		nextMessage();
		//StartCoroutine (nextWithWaitSpriteAnimator ());
		//continueButton.interactable=true;
	}
	IEnumerator fadeBGM(bool x){
		//continueButton.interactable=false;
		//messageScrolling = true;
		if (x==true) {// if true, fade in
			BGM.volume = 0f;
			BGM.Play ();
			while (BGM.volume <1f) {
				BGM.volume += 0.014f;
				yield return null;
				//Debug.Log(BGM.volume);
			}
		} else {//fade out
			BGM.volume=1f;
			while (BGM.volume > 0.01f) {
				BGM.volume -= 0.014f;
				yield return null;
				//Debug.Log(BGM.volume);
			}
			BGM.Stop ();
			//Debug.Log("fadeoutEndded");
		}
		//messageScrolling = false;
		//continueButton.interactable=true;
	}
	void playClip(int x){			//function read in c# script
		soundclip.clip = clip [x];
		soundclip.Play ();
	}
	void changeBG(int x){
		background.GetComponent<Image> ().sprite = backgrounds [x];
	
	}
	void changeSceneForReturn(int x){	//change scene that have PlayerPrefs
		lineCounter++;
		SceneManagerClass.conversationSetGamePref (dialougeFileName, lineCounter);
		StartCoroutine (sceneManager.changeSceneWithLoadingEnum (x));
		//SceneManagerClass.changeScene (x);
	}
	void changeSceneNoReturn(int x){	//change scene and destroy PlayerPrefs
		lineCounter++;
		PlayerPrefs.DeleteKey ("dialougeFile");
		PlayerPrefs.DeleteKey ("lineCounter");
		StartCoroutine (sceneManager.changeSceneWithLoadingEnum (x));
		//SceneManagerClass.changeScene (x);
	}
	IEnumerator transationSpriteXPosition(int spriteIndex,float position,string isSingular,float duration= 2f){
		
		sprites[spriteIndex].transform.DOLocalMoveX(position,duration);
		yield return null;
		lineCounter++;
		
		if(isSingular.Equals("false")){
			messageScrolling = false;
			nextMessage();
		}else{
			yield return new WaitForSeconds(duration);
			messageScrolling = false;
			nextMessage();
		}
	}
	IEnumerator spriteAnimation(int spriteIndex,string animation,string isSingular,float duration= 2.5f){
		
		switch (animation){
			case "shake":

			break;


		}
		yield return null;
		lineCounter++;
		messageScrolling = false;
		if(isSingular.Equals("false")){
			nextMessage();
		}else{
			yield return new WaitForSeconds(duration);
			nextMessage();
		}
	}
	IEnumerator tintSprite(int spriteIndex,string color,string isSingular){
		if(color.Equals("black")){
			sprites[spriteIndex].DOColor(new Color(0.5f,0.5f,0.5f,1f),1f);
		}else{
			sprites[spriteIndex].DOColor(Color.white,1f);
		}
		yield return null;
		lineCounter++;
		messageScrolling = false;
		if(isSingular.Equals("false")){
			nextMessage();
		}
	}
	IEnumerator closeDialougeWindow(string withFade){

		if(withFade.Equals("false")){
			dialougeWindow.gameObject.SetActive(false);
			
							
		}else{
			charName.gameObject.GetComponent<Text> ().text="";
			textBox.gameObject.GetComponent<Text> ().text="";
			dialougeWindow.GetComponentInChildren<Image>().DOColor(Color.clear,1f);
			yield return new WaitForSeconds(1f);
			dialougeWindow.gameObject.SetActive(false);
			dialougeWindow.GetComponentInChildren<Image>().color=Color.white;
							
		}
		yield return null;
		lineCounter++;
		messageScrolling = false;
		nextMessage();
	}
	IEnumerator openDialougeWindow(string withFade){
		yield return null;
	}
	IEnumerator playClipDialouge(int x){
		playClip (x);
		yield return new WaitForSeconds (1f);
		nextMessage ();
	}
	IEnumerator playClipDialougeNoWait(int x){
		playClip (x);
		yield return null;
		nextMessage ();
	}
	IEnumerator fadeBG(int x){
		lineCounter++;
		continueButton.interactable = false;
		Animation temp = background.GetComponent<Animation> ();
		//AnimationClip clips;
		if (x == -1) {//fade out
		//	clips=temp.GetClip("backgroundFadeOut");
		//	temp.clip = clips;
			temp.Play ("backgroundFadeOut");
		} else {	//fadein
	//		clips=temp.GetClip("backgroundFadeIn");
	//		temp.clip = clips;
			//background.GetComponent<Image>().color=new Color(1f,1f,1f,0f);
			background.GetComponent<Image> ().sprite = backgroundArray [x];
			temp.Play ("backgroundFadeIn");
		}
		yield return new WaitForSeconds (1.5f);
		messageScrolling = false;
		StartCoroutine (nextWithWaitSpriteAnimator ());
		continueButton.interactable = true;
	}
	IEnumerator fadeInFromBlack(float duration,string isSingular){
		displayTint.GetComponent<Image>().color=Color.black;
		displayTint.GetComponent<Image>().DOColor(Color.clear,duration);
		yield return new WaitForSeconds(duration);
		lineCounter++;
		messageScrolling = false;
		if(isSingular.Equals("false")){
			nextMessage();
		}
	}
	IEnumerator fadeOutToBlack(float duration,string isSingular){
		displayTint.GetComponent<Image>().DOColor(Color.black,duration);
		yield return new WaitForSeconds(duration);
		lineCounter++;
		messageScrolling = false;
		if(isSingular.Equals("false")){
			nextMessage();
		}
	}
	void instantiateSelection(int x){
		selectionButtons = new GameObject[x];
		int []selectionIndex=new int[x];
		selectionLine tempLine;
		int lineCounterTemp = lineCounter;
		int counter = 0;
		//pressObject.SetActive (false);
		//selection usejump to line function
		if (Application.platform == RuntimePlatform.Android) {
			
		} else {
			for (int i = lineCounterTemp; i < lineCounterTemp + x; i++) {
				selectionButtons [counter] = instantiateButton ();
				tempLine = lines [i] as selectionLine;
				Debug.Log("Line number"+i);
				Debug.Log(tempLine);
				selectionIndex [counter] = int.Parse(tempLine.getLineIndex ());
				selectionButtons [counter].GetComponentInChildren<Text> ().text = tempLine.getSelectionTag ();
				counter++;
				lineCounter++;
			}
		}

		for (int i = 0; i < x; i++) {
			int z=selectionIndex[i];
			selectionButtons[i].GetComponent<Button> ().onClick.AddListener (() =>selectionChoice (z));
			selectionButtons [i].GetComponent<Button> ().interactable = false;
			//	Debug.Log (selectionIndex[i]);
		}
		charaWindow.SetActive(false);
		StartCoroutine (enableSelection (selectionButtons));

	}
	IEnumerator enableSelection(GameObject[] buttonList){
		yield return new WaitForSeconds (0.5f);
		for (int i = 0; i < buttonList.Length; i++) {
			buttonList [i].GetComponent<Button> ().interactable = true;
		}
	}

	void setPrefInt(string changePref,int parameter){
		continueButton.interactable = false;
		PlayerPrefs.SetInt (changePref, parameter);
		lineCounter++;
		messageScrolling = false;
		StartCoroutine (nextWithWaitSpriteAnimator ());
		continueButton.interactable = true;

	}
	void setPrefString(string changePref,string parameter){
		continueButton.interactable = false;
		PlayerPrefs.SetString (changePref, parameter);
		lineCounter++;
		messageScrolling = false;
		StartCoroutine (nextWithWaitSpriteAnimator ());
		continueButton.interactable = true;
	}
	void enableCharaChapter(string charaPref,int parameter){
		continueButton.interactable = false;
		bool[] charaTemp = VNPrefs.GetBoolArray (charaPref);
		charaTemp [parameter] = true;
		VNPrefs.SetBoolArray (charaPref, charaTemp);
		lineCounter++;
		messageScrolling = false;
		StartCoroutine (nextWithWaitSpriteAnimator ());
		continueButton.interactable = true;
	}
	void enableCGReward(string prefName,int arrayNumber){
		continueButton.interactable = false;
		bool[] charaTemp = VNPrefs.GetBoolArray (prefName);
		charaTemp [arrayNumber] = true;
		VNPrefs.SetBoolArray (prefName, charaTemp);
		lineCounter++;
		messageScrolling = false;
		StartCoroutine (nextWithWaitSpriteAnimator ());
		continueButton.interactable = true;
	}
	IEnumerator toggleSelection (){
		yield return new WaitForSeconds (1f);
	
	}
	IEnumerator delayedChangeBoolScrolling(float x){
		yield return new WaitForSeconds (x);
		messageScrolling = false;
	}
	IEnumerator haltContinueButton(float x){
		continueButton.interactable = false;
		yield return new WaitForSeconds (x);
		continueButton.interactable = true;
	}
	IEnumerator nextWithWaitSpriteAnimator(){
		if (!sprites [0].gameObject.activeSelf) {
			yield return null;
			Debug.Log("nvm");
		} else {
			Debug.Log("it's loopiiiing");
			//yield return new WaitUntil (() => sprites [0].gameObject.GetComponent<Animator> ().isInitialized);
		}
		nextMessage ();
	}
	void changeCharaBox(string charaName){
		if (charaName == "Miyuki") {
			charaWindow.GetComponent<Image> ().sprite = charaWindowSprite [0];
			charaWindow.SetActive (true);
		} else if (charaName == "Mizuo") {
			charaWindow.GetComponent<Image> ().sprite = charaWindowSprite [1];
			charaWindow.SetActive (true);
		} else {
			charaWindow.SetActive (false);
			//charaWindow.GetComponent<Image> ().sprite = charaWindowSprite [2];
		}
	}
}