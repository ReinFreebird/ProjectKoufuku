using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainGame : MonoBehaviour {

    public GameObject w_characterInfo;
    public GameObject w_playerStatus;
    public GameObject w_schedule;
    public GameObject w_menu;
    

    public static Character character;
    public static Player player;
	// Use this for initialization
	void Start () {
        character = new Character("Miyuki", "Fukuroune");
        character.StageName = "MIYUKI";
        character.Popularity = 2000;
        character.Motivation = 100;
        character.Fiery = 3547;
        character.Coolish = 3259;
        character.Calming = 3543;
        character.Vocal = 1250;
        character.Expression = 850;
        character.Dance = 500;
        character.Confidence = 10;
        character.Ethic = 25;
        character.Social = 10;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public static Character GetCharacter()
    {
        return character;
    }
}
