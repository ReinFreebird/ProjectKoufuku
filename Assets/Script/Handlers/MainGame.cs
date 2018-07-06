using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainGame : MonoBehaviour {

    /// <summary>DoWork is a method in the TestClass class.
    /// <para>Here's how you could make a second paragraph in a description. <see cref="System.Console.WriteLine(System.String)"/> for information about output statements.</para>
    /// <seealso cref="this"/>
    /// </summary>
    public GameObject w_characterInfo;
    private CharacterInfoHandler s_characterInfo;
    public GameObject w_playerStatus;
    private StatusHandler s_playerStatus;
    public GameObject w_schedule;
    private ScheduleHandler s_schedule;
    public GameObject w_menu;
    public GameObject w_saveload;
    private SaveLoadHandler s_saveload;

    public static Character character;
    public static Player player;
    public static SaveData currentSave;

    private int currentSaveIndex;
    public bool b_playerStatus=false;
    public bool b_characterInfo=false;
    public bool b_schedule=false;
    public bool b_saveload = false;
    void Awake()
    {
        
        s_schedule = w_schedule.GetComponent<ScheduleHandler>();
        s_playerStatus = w_playerStatus.GetComponent<StatusHandler>();
        s_characterInfo = w_characterInfo.GetComponent<CharacterInfoHandler>();
        s_saveload = w_saveload.GetComponent<SaveLoadHandler>();

        //debugData();
        /*uncoment to make new file*/

        currentSave = SaveLoadManager.loadData(1);
        //currentSave = SaveLoadManager.loadData(1);
        player = currentSave.GetPlayer();
        character = currentSave.GetCharacter();
    }
    private void debugData()
    {


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

        character.CurrentStamina = 120;
        character.MaxStamina = 120;
        character.Health = 100;
        player = new Player();
        player.Name = "Rein";
        player.ProductionName = "Arcana Entertainment";
        player.Money = 1000;
        player.Days = 1;
        currentSaveIndex = 1;
        /*uncoment to make new file*/


        SaveLoadManager.saveData(player, character, 1);
    }
	// Use this for initialization
	void Start () {
        
        w_schedule.SetActive(b_schedule);
        w_playerStatus.SetActive(b_playerStatus);
        w_characterInfo.SetActive(b_characterInfo);
        w_saveload.SetActive(b_saveload);
        //SaveLoadManager.saveData(player, character, 1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void openWindow(int index)
    /*index
     * 0=main (disable all)
     * 1=characterInfo
     * 2=schedule
     *
     */
    {
        w_characterInfo.SetActive(false);
        w_playerStatus.SetActive(true);
        w_schedule.SetActive(false);
        switch (index)
        {
            case 0:
                break;
            case 1:
                
                w_characterInfo.SetActive(true);
                s_characterInfo.updateCharacterInfo();
                w_playerStatus.SetActive(false);
                break;
            case 2:
                w_schedule.SetActive(true);
                break;
        }
    }
    public static Character GetCharacter()
    {
        return character;
    }
    //For debug purpose
    public void startActivity(int index)
    {
        w_schedule.GetComponent<ScheduleHandler>().startActivity(index);
        //w_characterInfo.GetComponent<CharacterInfoHandler>().updateCharacterInfo();
        w_playerStatus.GetComponent<StatusHandler>().updatePlayerStatus();
    }
    public void resetSchedule()
    {
        
        s_schedule.Activities = new Activity[3];
        s_schedule.i_scheduleDayLogo.sprite = null;
        s_schedule.i_scheduleNoonLogo.sprite = null;
        s_schedule.i_scheduleEveningLogo.sprite = null;
    }
    public static void updateCharacter()
    {

    }
    public void startSchedule()
    {
        for (int i = 0; i < 3; i++)
        {
            s_schedule.startActivity(i);
        }
        resetSchedule();
        player.Days++;
        s_playerStatus.updatePlayerStatus();
        //s_characterInfo.updateCharacterInfo();

    }
}
