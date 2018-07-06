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

    public Image I_activityLogo
    {
        get
        {
            return i_activityLogo;
        }

        set
        {
            i_activityLogo = value;
        }
    }

    public Text T_activityName
    {
        get
        {
            return t_activityName;
        }

        set
        {
            t_activityName = value;
        }
    }

    public Text T_activityAttribute
    {
        get
        {
            return t_activityAttribute;
        }

        set
        {
            t_activityAttribute = value;
        }
    }

    public void setCharacter(Activity act)
    {
        activity = act;
    }
    
}
