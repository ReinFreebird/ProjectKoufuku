using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ContentSelectble : MonoBehaviour,ISelectHandler, IPointerEnterHandler,IPointerExitHandler {

    
    private GameObject w_schedule;
    private GameObject w_playerStatus;
    private ScheduleHandler s_schedule;
    private ActivityContent s_activityContent;
    private static bool isHighlighted = false;
    void Awake()
    {
        w_schedule = GameObject.FindGameObjectWithTag("Schedule");
        Debug.Log(w_schedule.name);
        s_schedule = w_schedule.GetComponent<ScheduleHandler>();
        s_activityContent = this.GetComponent<ActivityContent>();
    }
    
    public void OnSelect(BaseEventData eventData)
    {
        s_schedule.Activities[s_schedule.CurrentSchedule] = s_activityContent.activity;
        switch (s_schedule.CurrentSchedule)
        {
            case 0:
                s_schedule.i_scheduleDayLogo.sprite = s_activityContent.activity.logo;
                break;
            case 1:
                s_schedule.i_scheduleNoonLogo.sprite = s_activityContent.activity.logo;
                break;
            case 2:
                s_schedule.i_scheduleEveningLogo.sprite = s_activityContent.activity.logo;
                break;
        }
        s_schedule.resetDescription();
        s_schedule.CurrentSchedule = -1;
        s_schedule.c_scheduleList.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("lol");
        s_schedule.t_activityDetails.text = s_activityContent.activity.activityDetail;
        s_schedule.t_activityGain.text = "wry";
        s_schedule.t_activityRequirement.text = "zura";
        isHighlighted = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHighlighted = false;
        s_schedule.resetDescription();
        Debug.Log("haha");
    }
}
