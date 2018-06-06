using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character{

    private string firstName;
    private string lastName;
    private string stageName;


    //Basic stats
    private int currentStamina;
    private int maxStamina;
    private int popularity;


    //Skill ( 0 to *)
    private int vocal;
    private int expression;
    private int dance;

    //

    //work ( -50 to 50)
    private int confidence; //negative = timid, positive = confident
    private int ethic; //negative = lazy, positive = hard-working
    private int social; //negative = asocial, positive= socialable
    
    

    public Character(string first, string last)
    {
        firstName = first;
        lastName= last;
        maxStamina = 100;
    }

    public string StageName
    {
        get
        {
            return stageName;
        }
        set
        {
            stageName = value;
        }
    }
    public int CurrentStamina
    {
        get
        {
            return currentStamina;
        }

        set
        {
            currentStamina = value;
        }
    }
    public int MaxStamina
    {
        get
        {
            return maxStamina;
        }

        set
        {
            maxStamina = value;
        }
    }
    public int Popularity
    {
        get
        {
            return popularity;
        }
        set
        {
            popularity = value;
        }
    }

}
