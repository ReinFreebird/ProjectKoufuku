using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentMouseOver : MonoBehaviour {

    private bool isHighlighted=false;
    private ActivityContent s_activityContent;

    void Awake()
    {
        s_activityContent = this.GetComponent<ActivityContent>();
    }
    void OnMouseOver()
    {
        Debug.Log("lol");
        isHighlighted = true;

    }
    void OnMouseExit()
    {
            isHighlighted = false;
       
    }
    void activityDescription()
    {
        /*
        if (isHighlighted)
        {
            ScheduleHandler.t_activityDetails.text = s_activityContent.activity.activityDetail;
            ScheduleHandler.t_activityGain.text = "wry";
            ScheduleHandler.t_activityRequirement.text = "zura";
        }
        else
        {
            Debug.Log("un-lol");
            ScheduleHandler.t_activityDetails.text = "";
            ScheduleHandler.t_activityGain.text = "";
            ScheduleHandler.t_activityRequirement.text = "";
        }
        */
    }
}
