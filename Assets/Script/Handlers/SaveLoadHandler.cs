using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SaveLoadHandler : MonoBehaviour{

    public GameObject pref_saveFile;
    public GameObject c_saveList;
    public GameObject w_popup;
    private PopupHandler s_popup;
    private List<GameObject> b_saveList;
    private List<SaveData> saveDatas;
    /*saveNum=index+1
     * save1= saveDatas[0]
     */
    private bool isSave=false;
    private int selectData;
    public bool IsSave
    {
        get
        {
            return isSave;
        }

        set
        {
            isSave = value;
        }
    }


    /*true=save
     * false=load;
     */
    // Use this for initialization
    void Start () {
        updateSaveList();
        toggleSaveLoad(IsSave);
	}
    public void updateSaveList()
    {
        Debug.Log(c_saveList.transform.childCount);
        int x = 0;

        //Array to hold all child obj
        GameObject[] allChildren = new GameObject[c_saveList.transform.childCount];

        //Find all child obj and store to that array
        foreach (Transform child in c_saveList.transform)
        {
            allChildren[x] = child.gameObject;
            x += 1;
        }

        //Now destroy them
        foreach (GameObject child in allChildren)
        {
            DestroyImmediate(child.gameObject);
        }

        Debug.Log(transform.childCount);
        saveDatas = SaveLoadManager.GetSaveDatas();
        b_saveList = new List<GameObject>();
        GameObject temp;
        SaveFileContent contentTemp;
        for (int i = 0; i < saveDatas.Count; i++)
        {
            temp = GameObject.Instantiate(pref_saveFile, c_saveList.transform);
            temp.name += "" + (i + 1);
            b_saveList.Add(temp);
            contentTemp = temp.GetComponent<SaveFileContent>();
            contentTemp.t_saveNum.text = "#" + (i + 1);

            if (saveDatas[i] != null)
            {
                temp.GetComponent<Button>().interactable = true;
                contentTemp.SaveData = saveDatas[i];
                contentTemp.t_names.text = "Name: " + saveDatas[i].name + "\nProduction Name: " + saveDatas[i].productionName +
                    "\nIdol: " + saveDatas[i].GetCharacter().StageName;
                contentTemp.t_daysAndMoney.text = "Days: " + saveDatas[i].days + "\nMoney: $" + saveDatas[i].money;
                contentTemp.t_date.text = saveDatas[i].saveTime;
            }
        }
    }
	public void toggleSaveLoad(bool isSave)
    {
        //GameObject[] saveList = c_saveList.GetComponentsInChildren<GameObject>();

        /*new List<GameObject>();
        saveList.Add(c_saveList.transform.GetChild(0).GetComponent<GameObject>());
        saveList.Add(c_saveList.transform.GetChild(1).GetComponent<GameObject>());
        saveList.Add(c_saveList.transform.GetChild(2).GetComponent<GameObject>());
        saveList.Add(c_saveList.transform.GetChild(3).GetComponent<GameObject>());
        saveList.Add(c_saveList.transform.GetChild(4).GetComponent<GameObject>());

        */

        for (int i = 0; i < 5; i++)
        {
            if (isSave)
            {
                b_saveList[i].GetComponent<Button>().interactable = true;

            }
            else
            {
                if (saveDatas[i] != null)
                {
                    b_saveList[i].GetComponent<Button>().interactable = true;
                    Debug.Log("true");
                }
                else
                {
                    b_saveList[i].GetComponent<Button>().interactable = false;
                    Debug.Log("false");
                }
            }
        }
        
    }
    public void activeSaveLoad(int saveNum)
    {
        selectData = saveNum;
        w_popup.SetActive(true);
        s_popup = w_popup.GetComponent<PopupHandler>();
        s_popup.enableSaveLoadPopup(isSave);
        
    }
    public void saveLoadPopupPress(bool isSave)
    {
        if (isSave)
        {
            SaveLoadManager.saveData(MainGame.player, MainGame.character, selectData);
            updateSaveList();
        }
        else
        {
            SaveLoadManager.loadData(selectData);
        }
    }
    public void confirmSaveLoad(bool yes)
    {
        if (yes)
        {
            saveLoadPopupPress(isSave);
        }
        w_popup.SetActive(false);
    }

}
