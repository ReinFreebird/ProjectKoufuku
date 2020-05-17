using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
public class Dialouge:MonoBehaviour{
	string fileName;
	public string jsonString;
	List<dialougeLine> lines = new List<dialougeLine> ();
	//list to contain strings. Will this be necessary?
	List<CharacterContainer> charaList=new List<CharacterContainer>();//file value index 0
	List<string> dialougeList=new List<string>();//file value index 1
	List<int> spriteList = new List<int> ();//file value index 2
	Sprite[][]  charaSprite;//[x][y] x = chara index(equals to list array), y=sprite index
	//for android use
	List<string>charaIDContainer= new List<string>();
	public Dialouge(string fileName){
		//Debug.Log ("Dialouge called");
		//line is used to contain string from file
		string line = "";
		string path;
		if(Application.platform == RuntimePlatform.Android){// if running in android
			
		}else{
			path = Application.dataPath + "/StreamingAssets/Dialouge/";
			this.fileName = path+""+fileName+".vnsc";
			StreamReader r = new StreamReader (this.fileName);
			using (r) {
				line = r.ReadLine ();
				do {
					//Chara Index#Line#SpriteIndex
					string[] file_value = line.Split ('#');
					string test= file_value[0].Substring(0,1);
					Debug.Log(test);
					for (int i = 0; i < file_value.Length; i++) {

						//Check line contain
						//Debug.Log(file_value[i]);
					}

					//dialougeList.Add(file_value[1]);
					//spriteList.Add(int.Parse(file_value[2]));
					// check the value of file_value[0]
					Debug.Log (file_value[0]);
					if (file_value [0] == "F"||file_value [0] == "CC"||file_value [0] == "CI"||file_value [0] == "CS"||file_value [0] == "CB"||file_value [0] == "CCG") {//Line is function or changePref
						Debug.Log(file_value[1]);
						lines.Add (new dialougeLine (file_value [0],file_value [1],file_value [2],true));
					} else if (file_value[0]=="S"){	//Line is selection
								Debug.Log (file_value[2]);
						lines.Add(new selectionLine(file_value[1],file_value[2]));
					}else if (file_value [0] == "NULL") {	//No chara is speaking, narator
						lines.Add (new dialougeLine ("", file_value [1], file_value [2]));
					} else if (file_value[0]=="@"){
						if (!checkCharaList (file_value [0])) {//checking if chara is not in list. if true make new chara
							charaList.Add (new CharacterContainer (file_value [0]));
						}
						Debug.Log(lines.Count);
						lines.Add (new dialougeLine (charaList [getCharaIndex (file_value [0])].getCharaName (), file_value [1], file_value [2]));
						
					}else if (test.Equals("!")){
						lines.Add(new dialougeLine(file_value[0].Substring(1),null));
					}else{
						//is line
						lines.Add(new dialougeLine(null,file_value[0]));
					}
					line = r.ReadLine ();
				} while(line != null);
			}
			//Instansiate Sprite charaSprite array


				//Check charasprite[i]Length
				//	Debug.Log (charaSprite [i].Length);
				//	for (int j = 0; j < charaSprite [i].Length; j++) {
				//		Debug.Log (charaSprite [i] [j].ToString ());
				//	}
			}
			if (Application.platform == RuntimePlatform.Android) {
		
			}else{
			charaSprite = new Sprite[charaList.Count][];
			//Insert sprites into Dialouge charaSprite
			for (int i = 0; i < charaList.Count; i++) {
				charaSprite [i] = charaList [i].getSpriteArray ();
			
			}//File Format
			//charaID//"Line""//Sprite

			//Convert txt into json
			}
		}
	public string getFileName(){
		return fileName;
	}
	public List<string> getStringList(){
		return dialougeList;
	}
	public List<dialougeLine> getDialougeLine(){
		return lines;
	}
	public Sprite[][] getCharaSprite(){
		return charaSprite;
	}
	bool checkCharaList(string charID){
		//Check charaList for  charID. If list[0] is null, return false automatically
		if (charaList.Count==0) {
			return false;
		}
		for (int i = 0; i < charaList.Count; i++) {
			if (charID == charaList [0].getCharaID()) {
				return true;
			}
		}
		return false;
	}
	int getCharaIndex(string charID){
		for (int i = 0; i < charaList.Count; i++) {
			if (charID == charaList [i].getCharaID()) {
				return i;
			}
		}
		//if no match, return -1
		return -1;
	}
	public int getCharaNameIndex(string charName){
		for (int i = 0; i < charaList.Count; i++) {
			if (charName == charaList [i].getCharaName()) {
				return i;
			}
		}
		//if no match, return -1
		return -1;
	}
	void loadSprites(){
		string pathCharaJSon = "jar:file://" + Application.dataPath + "!/assets/CharacterCont/";
		string jsonFile;
		string pathCharaSprite;
		string spriteFile;
		Sprite [][] spriteContainer =new Sprite[charaIDContainer.Count][];
		Sprite[] singleContainer;
	}
}