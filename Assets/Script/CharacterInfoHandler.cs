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
    // Use this for initialization
    void Start () {
        changeName(ConstantManager.parameter.Expression.ToString());
	}
	
	public void changeName(string name)
    {
        t_stageName.text = name;
    }
}
