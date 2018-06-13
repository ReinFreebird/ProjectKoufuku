using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StatusHandler : MonoBehaviour {

    public Text t_playerName;
    public Text t_productionName;
    public Text t_days;
    public Text t_currentStamina;
    public Text t_maxStamina;
    public Image i_staminaBar;
    public Text t_motivation;
    public Image i_motivationBar;
    public Text t_health;
    public Image i_healthBar;
    public Text t_money;
    public Text t_popularity;
    //refrences to character and player data
    private Player player;
    private Character character;
    // Use this for initialization
    void Start()
    {
        player = MainGame.player;
        character = MainGame.character;
        updatePlayerStatus();
    }
    public void updatePlayerStatus()
    {
        Vector3 temp;
        t_days.text = player.Days.ToString();
        //Stamina
        t_currentStamina.text = character.CurrentStamina.ToString();
        t_maxStamina.text = "/" + character.MaxStamina;
        temp = i_staminaBar.rectTransform.localScale;
        temp.x = (float)character.CurrentStamina / (float)character.MaxStamina;
        i_staminaBar.rectTransform.localScale = temp;

        //Motivation
        t_motivation.text = character.Motivation.ToString()+"%";
        temp = i_motivationBar.rectTransform.localScale;
        temp.x = (float)character.Motivation / 100f;
        i_motivationBar.rectTransform.localScale = temp;

        //Health
        t_health.text = character.Health.ToString() + "%";
        temp = i_healthBar.rectTransform.localScale;
        temp.x = (float)character.Health / 100f;
        i_healthBar.rectTransform.localScale = temp;

        //Popularity
        t_popularity.text = character.Popularity.ToString();
        //Player
        t_days.text = player.Days.ToString();
        t_money.text = player.Money.ToString();
    }
}
