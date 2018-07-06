using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SaveFileContent : MonoBehaviour {

    public Text t_saveNum;
    public Text t_names;
    public Text t_daysAndMoney;
    public Text t_date;

    private SaveData saveData;

    public SaveData SaveData
    {
        get
        {
            return saveData;
        }

        set
        {
            saveData = value;
        }
    }

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
