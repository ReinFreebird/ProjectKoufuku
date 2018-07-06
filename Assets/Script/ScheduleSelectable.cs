using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ScheduleSelectable : MonoBehaviour, ISelectHandler
{
    [SerializeField]
    private GameObject w_schedule;
    private ScheduleHandler s_schedule;
    void Awake() {
        s_schedule = w_schedule.GetComponent<ScheduleHandler>();
    }
    public void OnSelect(BaseEventData eventData)
    {
        switch (eventData.selectedObject.name)
        {
            case "Day":s_schedule.CurrentSchedule= 0; break;
            case "Noon": s_schedule.CurrentSchedule = 1; break;
            case "Evening": s_schedule.CurrentSchedule = 2; break;
        }
        s_schedule.c_scheduleList.SetActive(true);
        Debug.Log(s_schedule.CurrentSchedule);
    }
}
