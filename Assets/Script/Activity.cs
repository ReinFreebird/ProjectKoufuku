using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Activity {

    public string activityName;
    public string activityDetail;
    public Sprite logo;
    private Character character;
    public int[] requirementParameter;
    public int[] requirementValue;
    public int[] gainParameter;
    public int[] gainValue;

    public Activity(ConstantManager.activity activity)
    {
        string logoPath = "ActivitySprites/";
        switch (activity)
        {
            
            case 0:
                /*Vocal Lesson
                *No requirement
                *Gain&loss:
                * Vocal= 50 + ((Ethics+Confidence)/10)
                * Stamina =-(10+ ((100-current motivation/10)+((100-current health)/5))
                * Health= -(max stamina-current stamina/20)
                * Motivation
                */
                logoPath += "activity00";

                
                break;
            case 1:
            case 2:

        }
    }

    private void startActivity()
    {
        for (int i = 0; i < gainParameter.Length; i++)
        {
            switch (gainParameter[i])
            {
                case 0:
                    character.Fiery += gainValue[i];
                    break;
                case 1:
                    character.Coolish += gainValue[i];
                    break;
                case 2:
                    character.Calming += gainValue[i];
                    break;
                case 3:
                    character.Vocal += gainValue[i];
                    break;
                case 4:
                    character.Expression += gainValue[i];
                    break;
                case 5:
                    character.Dance += gainValue[i];
                    break;
                case 6:
                    character.Confidence += gainValue[i];
                    break;
                case 7:
                    character.Ethic += gainValue[i];
                    break;
                case 8:
                    character.Social += gainValue[i];
                    break;
                default:break;
            }
        }
    }
}
