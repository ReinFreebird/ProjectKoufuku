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
    private int id_activity;
    /*
     * 
     * 
     * 
     */
    public int[] requirementParameter;
    public int[] requirementValue;
    public int[] gainParameter;
    public int[] gainValue;

    public Activity(ConstantManager.activity activity)
    {
        character = MainGame.character;
        player = MainGame.player;
        string logoPath = "ActivitySprites/";
        id_activity = (int)activity;
        switch (activity)
        {
            case ConstantManager.activity.VocalTraining:
                /*Vocal Lesson
                *No requirement
                *Gain&loss:
                * Vocal= 50 + ((Ethics+Confidence)/10)
                * Stamina =-(20+ ((100-current motivation/10)+((100-current health)/5))
                * Health= -(max stamina-current stamina/20)
                * Motivation= only if ethics are negative -(ethics/2.5)
                */
                activityName = "Vocal Training";
                activityDetail = "Spend your time training you vocal skills. Bonus point for high Confidence and Ethics";
                logoPath += "Activity00";
                gainParameter = new int[4];
                gainValue = new int[4];
                gainParameter[0] = (int)ConstantManager.parameter.Vocal;
                gainParameter[1] = (int)ConstantManager.parameter.CurrentStamina;
                gainParameter[2] = (int)ConstantManager.parameter.Health;
                gainParameter[3] = (int)ConstantManager.parameter.Motivation;
                
                break;
            case ConstantManager.activity.ExpressionTraining:
                /*ExpressionTraining
                *No requirement
                *Gain&loss:
                * Expression= 50 + ((Social+Confidence)/10)
                * Stamina =-(20+ ((100-current motivation/10)+((100-current health)/5))
                * Health= -(max stamina-current stamina/20)
                * Motivation= only if ethics are negative -(ethics/2.5)
                */
                activityName = "Expression Training";
                activityDetail = "Spend your time training you expressive skills. Bonus point for high Confidence and Social";
                logoPath += "Activity01";
                gainParameter = new int[4];
                gainValue = new int[4];
                gainParameter[0] = (int)ConstantManager.parameter.Expression;
                gainParameter[1] = (int)ConstantManager.parameter.CurrentStamina;
                gainParameter[2] = (int)ConstantManager.parameter.Health;
                gainParameter[3] = (int)ConstantManager.parameter.Motivation;
                break;
            case ConstantManager.activity.DanceTraining:
                /*Dance Training
                *No requirement
                *Gain&loss:
                * Dance= 50 + ((Social+Ethics)/10)
                * Stamina =-(20+ ((100-current motivation/10)+((100-current health)/5))
                * Health= -(max stamina-current stamina/20)
                * Motivation= only if ethics are negative -(ethics/2.5)
                */
                activityName = "Dance Training";
                activityDetail = "Spend your time training you dancing skills. Bonus point for high Ethics and Social";
                logoPath += "Activity02";
                gainParameter = new int[4];
                gainValue = new int[4];
                gainParameter[0] = (int)ConstantManager.parameter.Dance;
                gainParameter[1] = (int)ConstantManager.parameter.CurrentStamina;
                gainParameter[2] = (int)ConstantManager.parameter.Health;
                gainParameter[3] = (int)ConstantManager.parameter.Motivation;
                break;
            case ConstantManager.activity.FlyerHandouts:
                /*FlyerHandouts
                *No requirement
                * Description: Giving Flyers to strangers. Increase Confidence, and a bit of popularity
                *Gain&loss:
                * Confidence= 1 + ((currentMotivation/100)*2)
                * Stamina =-(10+ ((100-current motivation/10)+((100-current health)/5))
                * Health= -(max stamina-current stamina/20)
                * Motivation= -(10 -(currentConfidence/5));
                * Popularity= 5+( (only if positive confidence/50)*popularity*3)
                * Money= $50;
                */
                activityName = "Flyer Handouts";
                activityDetail = "Giving Flyers to strangers. Increase Confidence and a bit of Popularity";
                logoPath += "Activity03";
                gainParameter = new int[6];
                gainValue = new int[6];
                gainParameter[0] = (int)ConstantManager.parameter.Confidence;
                gainParameter[1] = (int)ConstantManager.parameter.CurrentStamina;
                gainParameter[2] = (int)ConstantManager.parameter.Health;
                gainParameter[3] = (int)ConstantManager.parameter.Motivation;
                gainParameter[4] = (int)ConstantManager.parameter.Popularity;
                gainParameter[5] = (int)ConstantManager.parameter.Money;
                break;
            case ConstantManager.activity.Volunteer:
                /*Volunteer
                *No requirement
                * Description: Helping out people. Increase Confidence, and a bit of popularity
                *Gain&loss:
                * Ethic= 1 + ((currentMotivation/100)*2)
                * Stamina =-(10+ ((100-current motivation/10)+((100-current health)/5))
                * Health= -(max stamina-current stamina/20)
                * Motivation= -(10 -(currentEthic/5));
                * Popularity= 5+( (only if positive ethic/50)*popularity*3)
                * Money= $50;
                */
                activityName = "Volunteer";
                activityDetail = "Helping out other peoples. Increase Ethics and a bit of Popularity";
                logoPath += "Activity04";
                gainParameter = new int[6];
                gainValue = new int[6];
                gainParameter[0] = (int)ConstantManager.parameter.Ethics;
                gainParameter[1] = (int)ConstantManager.parameter.CurrentStamina;
                gainParameter[2] = (int)ConstantManager.parameter.Health;
                gainParameter[3] = (int)ConstantManager.parameter.Motivation;
                gainParameter[4] = (int)ConstantManager.parameter.Popularity;
                gainParameter[5] = (int)ConstantManager.parameter.Money;
                break;
            case ConstantManager.activity.Hangout:
                /*Hangout
                *No requirement
                * Description: Helping out people. Increase Confidence, and a bit of popularity
                *Gain&loss:
                * Ethic= 1 + ((currentMotivation/100)*2)
                * Stamina =-(10+ ((100-current motivation/10)+((100-current health)/5))
                * Health= -(max stamina-current stamina/20)
                * Motivation= -(10 -(currentEthic/5));
                * Popularity= 5+( (only if positive ethic/50)*popularity*3)
                * Money= $50;
                */
                activityName = "Hangout";
                activityDetail = "Hangout with peoples you know. Increase Social and a bit of Popularity";
                logoPath += "Activity05";
                gainParameter = new int[6];
                gainValue = new int[6];
                gainParameter[0] = (int)ConstantManager.parameter.Social;
                gainParameter[1] = (int)ConstantManager.parameter.CurrentStamina;
                gainParameter[2] = (int)ConstantManager.parameter.Health;
                gainParameter[3] = (int)ConstantManager.parameter.Motivation;
                gainParameter[4] = (int)ConstantManager.parameter.Popularity;
                gainParameter[5] = (int)ConstantManager.parameter.Money;
                break;
            case ConstantManager.activity.Rest:
                /*Rest
                *No requirement
                * Description: Take your time to rest. Recover stamina, motivation and health
                *Gain&loss:
                * Stamina = maxStamina*40%
                * Health= health*10%
                * Motivation= maxMotivation*25%
                */
                activityName = "Rest";
                activityDetail = "Take your time to rest. Recover stamina, motivation and health.";
                logoPath += "Activity06";
                gainParameter = new int[3];
                gainValue = new int[3];
                gainParameter[0] = (int)ConstantManager.parameter.Social;
                gainParameter[1] = (int)ConstantManager.parameter.CurrentStamina;
                gainParameter[2] = (int)ConstantManager.parameter.Health;
                break;
        }
        logo = Resources.Load<Sprite>(logoPath) as Sprite;
    }
    
    void calibrateParameter()
    {
        switch (id_activity)
        {
            case (int)ConstantManager.activity.VocalTraining:
                /*Vocal Training
                 * 
                 * 
                 */

                gainValue[0] = 50 + ((character.Ethic + character.Confidence) / 10);
                gainValue[1] = -(20 + (((100 - character.Motivation) / 10)) + ((100 - character.Health) / 10));
                Debug.Log(gainValue[1]);
                gainValue[2] = -((character.MaxStamina - character.CurrentStamina) / 20);
                gainValue[3] = (character.Ethic < 0) ? -(int)(character.Motivation / 2.5) : 0;
                break;
            case (int)ConstantManager.activity.ExpressionTraining:
                /*ExpressionTraining
                */
                gainValue[0] = 50 + ((character.Social + character.Confidence) / 10);
                gainValue[1] = -(20 + (((100 - character.Motivation) / 10)) + ((100 - character.Health) / 10));
                Debug.Log(gainValue[1]);
                gainValue[2] = -((character.MaxStamina - character.CurrentStamina) / 20);
                gainValue[3] = (character.Social < 0) ? -(int)(character.Motivation / 2.5) : 0;
                break;
            case (int)ConstantManager.activity.DanceTraining:
                /*Dance Training
                */
                gainValue[0] = 50 + ((character.Social + character.Ethic) / 10);
                gainValue[1] = -(20 + (((100 - character.Motivation) / 10)) + ((100 - character.Health) / 10));
                Debug.Log(gainValue[1]);
                gainValue[2] = -(int)((character.MaxStamina - character.CurrentStamina) / 20);
                gainValue[3] = (character.Confidence < 0) ? -(int)(character.Motivation / 2.5) : 0;
                break;
            case (int)ConstantManager.activity.FlyerHandouts:
                /*FlyerHandouts
                */
                gainValue[0] = 1 + ((character.Motivation / 100) * 2);
                gainValue[1] = -(10 + (((100 - character.Motivation) / 10)) + ((100 - character.Health) / 5));
                gainValue[2] = -(int)((character.MaxStamina - character.CurrentStamina) / 20);
                gainValue[3] = -(int)(10 - (character.Confidence / 5));
                float confidenceRatio = (character.Confidence / 50 > 0) ? 0 : character.Confidence / 50;
                gainValue[4] = 5 + (int)(confidenceRatio * character.Popularity * 3);
                gainValue[5] = -50;
                break;
            case (int)ConstantManager.activity.Volunteer:
                /*Volunteer
                */
                
                gainValue[0] = 1 + ((character.Motivation / 100) * 2);
                gainValue[1] = -(10 + (((100 - character.Motivation) / 10)) + ((100 - character.Health) / 5));
                gainValue[2] = -(int)((character.MaxStamina - character.CurrentStamina) / 20);
                gainValue[3] = -(int)(10 - (character.Ethic / 5));
                float ethicRatio = (character.Ethic / 50 > 0) ? 0 : character.Ethic / 50;
                gainValue[4] = 5 + (int)(ethicRatio * character.Popularity * 3);
                gainValue[5] = -50;
                break;
            case (int)ConstantManager.activity.Hangout:
                /*Hangout*/
                gainValue[0] = 1 + ((character.Social / 100) * 2);
                gainValue[1] = -(5 + (((100 - character.Motivation) / 10)) + ((100 - character.Health) / 5));
                gainValue[2] = -(int)((character.MaxStamina - character.CurrentStamina) / 20);
                gainValue[3] = -(int)(20 - (character.Social / 5));
                float socialRatio = (character.Social / 50 > 0) ? 0 : character.Social / 50;
                gainValue[4] = 5 + (int)(socialRatio * character.Popularity * 3);
                gainValue[5] = -50;
                break;
            case (int)ConstantManager.activity.Rest:
                /*Rest*/
                gainValue[0] = (int)(character.MaxStamina * 4 / 10);
                gainValue[1] = (int)(character.Health / 10);
                gainValue[2] = 25;
                break;
        }
    }
    public void startActivity()
    {
        calibrateParameter();
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
