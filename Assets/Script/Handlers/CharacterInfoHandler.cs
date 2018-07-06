using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterInfoHandler : MonoBehaviour {

    public Text t_stageName;
    public Text t_realName;
    public Text t_popularity;
    public Text t_motivation;
    public Text t_idolLevel;
    public Text t_personality;
    //Appeal
    public Text t_appealFiery;
    public Text t_appealCoolish;
    public Text t_appealCalming;

    //Skill
    public Text t_skillVocal;
    public Image i_skillVocal;
    public Text t_skillExpression;
    public Image i_skillExpression;
    public Text t_skillDance;
    public Image i_skillDance;

    //Work
    public Text t_workConfidence;
    public Slider s_workConfidence;
    public Text t_workEthics;
    public Slider s_workEthics;
    public Text t_workSocial;
    public Slider s_workSocial;

    //refrences to character and player data
    private Player player;
    private Character character;
    // Use this for initialization
    void Awake()
    {
        player = MainGame.player;
        character = MainGame.character;
        updateCharacterInfo();
    }
    void Start () {
        
	}
	public void updateCharacterInfo()
    {
        t_stageName.text= character.StageName;
        t_realName.text = character.FirstName + " " + character.LastName;
        t_popularity.text = character.Popularity.ToString();
        t_motivation.text= GetMotivation();
        t_idolLevel.text= GetIdolLevel();
        t_personality.text=GetPersonality();
        //Appeal
        t_appealFiery.text=character.Fiery.ToString();
        t_appealCoolish.text = character.Coolish.ToString();
        t_appealCalming.text = character.Calming.ToString();

        //Skill
        //Vocal
        t_skillVocal.text=character.Vocal.ToString();
        Vector3 temp;
        temp = i_skillVocal.rectTransform.localScale;
        temp.x = (float)character.Vocal / 9999f;// 0 =228, full= 0
        i_skillVocal.rectTransform.localScale = temp;

        //Expression
        t_skillExpression.text=character.Expression.ToString();
        temp=i_skillExpression.rectTransform.localScale;
        temp.x = (float)character.Expression / 9999f;
        i_skillExpression.rectTransform.localScale = temp;

        //Dance
        t_skillDance.text=character.Dance.ToString();
        temp = i_skillDance.rectTransform.localScale;
        temp.x = (float)character.Dance / 9999f;
        i_skillDance.rectTransform.localScale = temp;




        //Work
        t_workConfidence.text=character.Confidence.ToString();
        s_workConfidence.value=character.Confidence;
        t_workEthics.text = character.Ethic.ToString();
        s_workEthics.value=character.Ethic;
        t_workSocial.text = character.Social.ToString() ;
        s_workSocial.value=character.Social;
       
    }
    public void changeName(string name)
    {
        t_stageName.text = name;
    }
    string GetIdolLevel()
    {
        return "Noob";
    }
    string GetPersonality()
    {
        return "Bland";
    }
    string GetMotivation()
    {
        string mot;
        int motInt = character.Motivation;
        if (motInt<=20)
        {
            mot = "Unmotivated";
        }else if (motInt <= 40)
        {
            mot = "Wavered";
        }else if (motInt<=60)
        {
            mot = "Neutral";
        }else if (motInt <= 80)
        {
            mot = "Motivated";
        }else if (motInt <= 90)
        {
            mot = "Driven";
        }
        else
        {
            mot = "On Fire";
        }

        return mot;
    }
}
