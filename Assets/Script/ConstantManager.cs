using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ConstantManager {

    public enum activity
    {
        VocalTraining, ExpressionTraining, DanceTraining,

    }
    public enum parameter
    {
        //15 parameters, character (0-13), player (14)
        Fiery, Coolish, Calming, Vocal, Expression, Dance, Confidence, Ethics, Social,CurrentStamina,MaxStamina,
        Motivation,Health,Popularity,Money 
    }
    //path to activitySprites, used for when instantiating activity
    public static string[] activityLogoPath =
    {
        "ActivitySprite/001","ActivitySprite/002",""
    };
}
