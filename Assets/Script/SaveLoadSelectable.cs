using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class SaveLoadSelectable : MonoBehaviour,ISelectHandler{

    private GameObject w_saveload;
    private SaveLoadHandler s_saveload;
    void Awake()
    {
        w_saveload = GameObject.FindGameObjectWithTag("SaveLoad");
        Debug.Log(w_saveload);
        s_saveload = w_saveload.GetComponent<SaveLoadHandler>();
    }
    public void OnSelect(BaseEventData eventData)
    {
        string saveIndex = eventData.selectedObject.name.Substring(15);
        Debug.Log(saveIndex);
        s_saveload.activeSaveLoad(int.Parse(saveIndex));

    }

}
