using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainGame : MonoBehaviour {

    //CharcaterInfo
    [SerializeField]
    public GameObject w_characterInfo;
    [SerializeField]
    public GameObject w_characterStatus;
    public Text t_days;
    public Text t_currentStamina;
    public Text t_maxStamina;
    public Image i_stamina;
    public Text t_motivationNumber;
    public Image i_motivationNumber;
    public Text t_health;
    public Image i_health;
    public Text t_money;
    public Text t_popularityNumber;



    [SerializeField]
    public GameObject w_schedule;
    

    public static Character character;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public static Character GetCharacter()
    {
        return character;
    }
}
