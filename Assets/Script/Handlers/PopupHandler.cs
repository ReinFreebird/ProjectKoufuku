using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PopupHandler : MonoBehaviour {

    [SerializeField]
    private GameObject w_saveloadPopup;
    [SerializeField]
    public Text t_saveloadText;

	void OnEnable()
    {

    }
    void OnDisable()
    {
        w_saveloadPopup.SetActive(false);
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
}
