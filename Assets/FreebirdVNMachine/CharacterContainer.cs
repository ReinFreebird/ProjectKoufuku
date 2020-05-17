using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class CharacterContainer : MonoBehaviour {

	//Image xxx = new Image();
	string charaID="";
	string fileName="";
	string name;
	public Sprite[] charaSprite;
	WWW wwwLink;
	public CharacterContainer(string fileID){
	//	Debug.Log ("Chara called");
		string line="";
		string path1;
		charaID = fileID;
		if (Application.platform == RuntimePlatform.Android) {// if running in android
			
		} else {
				path1 = Application.dataPath + "/StreamingAssets/Character/" ;
				this.fileName = path1 + "chara" + fileID + ".txt";
				StreamReader r = new StreamReader (this.fileName);
				//first Line charaID, no need to change
				line = r.ReadLine ();
				//	Debug.Log (line);
				//second line charaName
				line = r.ReadLine ();
				name = line;
				//	Debug.Log (name);
				//third line sprite file name. format=charaId[indexNum].png . remove bracket
				line = r.ReadLine ();
				string[] sprites = line.Split ('/');

				//	Debug.Log (sprites[0]);
				charaSprite = new Sprite[sprites.Length];
				for (int i = 0; i < charaSprite.Length; i++) {
					if (Application.platform == RuntimePlatform.Android) {// if running in android
					
					} else {
						string spritePath = "CharacterSprites/" + charaID + "/" + charaID + i.ToString ();
						//		Debug.Log (spritePath);
						charaSprite [i] = Resources.Load<Sprite> (spritePath)as Sprite;
					}
				}
			//Debug.Log (charaSprite.Length);
		}
	}
	public string getCharaID(){
		return charaID;
	}
	public string getCharaName(){
		return name;
	}
	public Sprite[] getSpriteArray(){
		return charaSprite;
	}
}
