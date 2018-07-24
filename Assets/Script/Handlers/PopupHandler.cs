using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PopupHandler : MonoBehaviour {

    [SerializeField]
    private GameObject w_saveloadPopup;
    [SerializeField]
    private GameObject w_notifyPopup;
    [SerializeField]
    public Text t_saveloadText;
    [SerializeField]
    public Text t_notifyPopup;

    private MainGame s_maingame;
    void Awake()
    {
        s_maingame = GameObject.FindGameObjectWithTag("MainGame").GetComponent<MainGame>();
    }
    void OnEnable()
    {
        
    }
    void OnDisable()
    {
        w_saveloadPopup.SetActive(false);
        w_notifyPopup.SetActive(false);
    }
    public void enableSaveLoadPopup(bool isSave)
    {
        if (isSave)
        {
            t_saveloadText.text = "Would you like to save the game?";
        }
        else
        {
            t_saveloadText.text = "Would you like to load the game?";
        }
        w_saveloadPopup.SetActive(true);

    }
    public void notify(string str)
    {
        w_saveloadPopup.SetActive(false);
        t_notifyPopup.text = str;
        w_notifyPopup.SetActive(true);
    }
    public void disablePopup()
    {
        this.gameObject.SetActive(false);
        //s_maingame.w_popup.SetActive(false);
    }
}