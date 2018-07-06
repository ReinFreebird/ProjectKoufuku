using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScheduleHandler : MonoBehaviour{

    public GameObject b_scheduleDay;
    public Image i_scheduleDayLogo;
    public GameObject b_scheduleNoon;
    public Image i_scheduleNoonLogo;
    public GameObject b_scheduleEvening;
    public Image i_scheduleEveningLogo;
    public GameObject l_scheduleList;
    public GameObject vp_scheduleList;
    public GameObject c_scheduleList;
    public GameObject pre_contents;
    public Text t_activityDetails;
    public Text t_activityRequirement;
    public Text t_activityGain;

    private Activity[] activities= new Activity[7];
    private Character character;
    private Player player;

    private int currentSchedule=-1;//0=day,1=noon,2=evening, else non

    public int CurrentSchedule
    {
        get
        {
            return currentSchedule;
        }

        set
        {
            currentSchedule = value;
        }
    }

    public Activity[] Activities
    {
        get
        {
            return activities;
        }

        set
        {
            activities = value;
        }
    }

    // Use this for initialization
    void Awake()
    {
        

    }
    void Start () {
        character = MainGame.character;
        player = MainGame.player;
        Activities[0] = new Activity(ConstantManager.activity.VocalTraining);
        Activities[1] = new Activity(ConstantManager.activity.ExpressionTraining);
        Activities[2] = new Activity(ConstantManager.activity.DanceTraining);
        Activities[3] = new Activity(ConstantManager.activity.FlyerHandouts);
        Activities[4] = new Activity(ConstantManager.activity.Volunteer);
        Activities[5] = new Activity(ConstantManager.activity.Hangout);
        Activities[6] = new Activity(ConstantManager.activity.Rest);
        GameObject temp;
        ActivityContent tempComponent;
        for (int i = 0; i < Activities.Length; i++)
        {
            temp= Instantiate(pre_contents, c_scheduleList.transform);
            tempComponent = temp.GetComponent<ActivityContent>();
            tempComponent.activity = Activities[i];
            tempComponent.T_activityName.text = tempComponent.activity.activityName;
            tempComponent.I_activityLogo.sprite =tempComponent.activity.logo;
        }
        c_scheduleList.SetActive(false);
    }
    void Update()
    {
        //b_scheduleDay.GetComponent<Button>()
    }
	public void chooseTime(int index)
    {
        
    }
	public void startActivity(int index)
    {
        Activities[index].startActivity();
    }
    public void resetDescription()
    {
        t_activityDetails.text = "";
        t_activityGain.text = "";
        t_activityRequirement.text = "";
    }
    //For debug Only
    public void resetCharaterStatus()
    {
        character.CurrentStamina = MainGame.GetCharacter().MaxStamina;
    }
    

}
