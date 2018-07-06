using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class SaveLoadToggle : MonoBehaviour, ISelectHandler{

    private GameObject w_saveload;
    private SaveLoadHandler s_saveload;
    private GameObject[] b_toggleTemp=new GameObject[2];
    void Awake()
    {
        w_saveload = GameObject.FindGameObjectWithTag("SaveLoad");
        s_saveload = w_saveload.GetComponent<SaveLoadHandler>();
    }
    public void OnSelect(BaseEventData eventData)
    {
        b_toggleTemp = GameObject.FindGameObjectsWithTag("SaveLoadToggle");
        GameObject selectedObject= eventData.selectedObject;
        for (int i = 0; i < b_toggleTemp.Length; i++)
        {
            b_toggleTemp[i].GetComponent<Button>().interactable = true;
        }
        s_saveload.IsSave = false;
        if (selectedObject.name.Contains("Save"))
        {
            
            s_saveload.IsSave = true;
        }
        s_saveload.toggleSaveLoad(s_saveload.IsSave);
        selectedObject.GetComponent<Button>().interactable = false;

    }
}
