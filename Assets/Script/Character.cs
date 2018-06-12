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
    private int motivation;//(0-100) 0-20= unmotivated, 21-40= wavered, 41-60 = neutral, 61-80 = motivated, 81-90 = driven, 91-100= on fire
    private int health;//(0-100)
    //Skill ( 1 to 9999)
    private int vocal;
    private int expression;
    private int dance;

    //Appeal
    private int fiery;
    private int coolish;
    private int calming;

    //work ( -50 to 50)
    private int confidence; //negative = timid, positive = confident
    private int ethic; //negative = lazy, positive = hard-working
    private int social; //negative = asocial, positive= socialable
    
    

    public Character(string first, string last)
    {
        FirstName = first;
        LastName= last;
        maxStamina = 100;
    }
    public int Motivation
    {
        get
        {
            return motivation;
        }
        set
        {
            motivation = value;
        }
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
    public int Vocal
    {
        get
        {
            return vocal;
        }

        set
        {
            vocal = value;
        }
    }
    public int Expression
    {
        get
        {
            return expression;
        }

        set
        {
            expression = value;
        }
    }
    public int Dance
    {
        get
        {
            return dance;
        }

        set
        {
            dance = value;
        }
    }
    public int Fiery
    {
        get
        {
            return fiery;
        }

        set
        {
            fiery = value;
        }
    }
    public int Coolish
    {
        get
        {
            return coolish;
        }

        set
        {
            coolish = value;
        }
    }
    public int Calming
    {
        get
        {
            return calming;
        }

        set
        {
            calming = value;
        }
    }
    public int Confidence
    {
        get
        {
            return confidence;
        }

        set
        {
            confidence = value;
        }
    }
    public int Ethic
    {
        get
        {
            return ethic;
        }

        set
        {
            ethic = value;
        }
    }
    public int Social
    {
        get
        {
            return social;
        }

        set
        {
            social = value;
        }
    }
    public int Health
    {
        get
        {
            return health;
        }

        set
        {
            health = value;
        }
    }

    public string FirstName
    {
        get
        {
            return firstName;
        }

        set
        {
            firstName = value;
        }
    }

    public string LastName
    {
        get
        {
            return lastName;
        }

        set
        {
            lastName = value;
        }
    }

    public string[] GetStrings()
    {
        string[] arrayString= { FirstName, LastName, stageName };
        return arrayString;
    }
    public int[] GetInts()
    {
        int[] intString= { fiery,coolish,calming,vocal,expression,dance,confidence,ethic,social,currentStamina,maxStamina
        ,motivation,health,popularity};
        return intString;
    }
}
