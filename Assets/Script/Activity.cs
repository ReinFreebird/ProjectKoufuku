using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Activity {

    public string activityName;
    public string activityDetail;
    public Sprite logo;
    private Character character;
    private Player player;
    public int[] requirementParameter;
    public int[] requirementValue;
    public int[] gainParameter;
    public int[] gainValue;

    public Activity(ConstantManager.activity activity)
    {
        string logoPath = "ActivitySprites/";
        switch (activity)
        {
            case ConstantManager.activity.VocalTraining:
                /*Vocal Lesson
                *No requirement
                *Gain&loss:
                * Vocal= 50 + ((Ethics+Confidence)/10)
                * Stamina =-(10+ ((100-current motivation/10)+((100-current health)/5))
                * Health= -(max stamina-current stamina/20)
                * Motivation= only if ethics are negative -(ethics/2.5)
                */
                activityName = "Vocal Training";
                activityDetail = "Spend your time training you vocal skills. Bonus point for high Confidence and Ethics";
                logoPath += "activity00";
                gainParameter = new int[4];
                gainParameter[0] = (int)ConstantManager.parameter.Vocal;
                gainParameter[1] = (int)ConstantManager.parameter.CurrentStamina;
                gainParameter[2] = (int)ConstantManager.parameter.Health;
                gainParameter[3] = (int)ConstantManager.parameter.Motivation;
                gainValue[0] = 50 + ((character.Ethic + character.Confidence) / 10);
                gainValue[1] = -(10+(((100-character.Motivation)/10))+((100-character.Health)/10));
                gainValue[2] = -((character.MaxStamina - character.CurrentStamina) / 20);
                gainValue[3] = (character.Ethic < 0) ?-(int)(character.Motivation/2.5): 0;
                break;
            case ConstantManager.activity.ExpressionTraining:
                /*ExpressionTraining
                *No requirement
                *Gain&loss:
                * Expression= 50 + ((Social+Confidence)/10)
                * Stamina =-(10+ ((100-current motivation/10)+((100-current health)/5))
                * Health= -(max stamina-current stamina/20)
                * Motivation= only if ethics are negative -(ethics/2.5)
                */
                activityName = "Expression Training";
                activityDetail = "Spend your time training you expressive skills. Bonus point for high Confidence and Social";
                logoPath += "activity01";
                gainParameter = new int[4];
                gainParameter[0] = (int)ConstantManager.parameter.Expression;
                gainParameter[1] = (int)ConstantManager.parameter.CurrentStamina;
                gainParameter[2] = (int)ConstantManager.parameter.Health;
                gainParameter[3] = (int)ConstantManager.parameter.Motivation;
                gainValue[0] = 50 + ((character.Social + character.Confidence) / 10);
                gainValue[1] = -(10 + (((100 - character.Motivation) / 10)) + ((100 - character.Health) / 10));
                gainValue[2] = -((character.MaxStamina - character.CurrentStamina) / 20);
                gainValue[3] = (character.Social < 0) ? -(int)(character.Motivation / 2.5) : 0;
                break;
            case ConstantManager.activity.DanceTraining:
                /*Dance Training
                *No requirement
                *Gain&loss:
                * Dance= 50 + ((Social+Ethics)/10)
                * Stamina =-(10+ ((100-current motivation/10)+((100-current health)/5))
                * Health= -(max stamina-current stamina/20)
                * Motivation= only if ethics are negative -(ethics/2.5)
                */
                activityName = "Dance Training";
                activityDetail = "Spend your time training you dancing skills. Bonus point for high Ethics and Social";
                logoPath += "activity02";
                gainParameter = new int[4];
                gainParameter[0] = (int)ConstantManager.parameter.Dance;
                gainParameter[1] = (int)ConstantManager.parameter.CurrentStamina;
                gainParameter[2] = (int)ConstantManager.parameter.Health;
                gainParameter[3] = (int)ConstantManager.parameter.Motivation;
                gainValue[0] = 50 + ((character.Social + character.Ethic) / 10);
                gainValue[1] = -(10 + (((100 - character.Motivation) / 10)) + ((100 - character.Health) / 10));
                gainValue[2] = -((character.MaxStamina - character.CurrentStamina) / 20);
                gainValue[3] = (character.Confidence < 0) ? -(int)(character.Motivation / 2.5) : 0;
                break;
        }
    }

    private void startActivity()
    {
        for (int i = 0; i < gainParameter.Length; i++)
        {
            switch (gainParameter[i])
            {
                case (int)ConstantManager.parameter.Fiery:
                    character.Fiery += gainValue[i];
                    break;
                case (int)ConstantManager.parameter.Coolish:
                    character.Coolish += gainValue[i];
                    break;
                case (int)ConstantManager.parameter.Calming:
                    character.Calming += gainValue[i];
                    break;
                case (int)ConstantManager.parameter.Vocal:
                    character.Vocal += gainValue[i];
                    break;
                case (int)ConstantManager.parameter.Expression:
                    character.Expression += gainValue[i];
                    break;
                case (int)ConstantManager.parameter.Dance:
                    character.Dance += gainValue[i];
                    break;
                case (int)ConstantManager.parameter.Confidence:
                    character.Confidence += gainValue[i];
                    break;
                case (int)ConstantManager.parameter.Ethics:
                    character.Ethic += gainValue[i];
                    break;
                case (int)ConstantManager.parameter.Social:
                    character.Social += gainValue[i];
                    break;
                case (int)ConstantManager.parameter.CurrentStamina:
                    character.CurrentStamina += gainValue[i];
                    break;
                case (int)ConstantManager.parameter.MaxStamina:
                    character.MaxStamina += gainValue[i];
                    break;
                case (int)ConstantManager.parameter.Motivation:
                    character.Motivation += gainValue[i];
                    break;
                case (int)ConstantManager.parameter.Health:
                    character.Health += gainValue[i];
                    break;
                case (int)ConstantManager.parameter.Popularity:
                    character.Popularity += gainValue[i];
                    break;
                case (int)ConstantManager.parameter.Money:
                    player.Money += gainValue[i];
                    break;
            }
        }
    }
}
