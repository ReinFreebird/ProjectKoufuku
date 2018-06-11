using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ActivityContent : MonoBehaviour {


    [SerializeField]
    private Image i_activityLogo;
    [SerializeField]
    private Text t_activityName;
    [SerializeField]
    private Text t_activityAttribute;
    // Use this for initialization

    public Activity activity;
    public void setCharacter(Activity act)
    {
        activity = act;
    }
}
