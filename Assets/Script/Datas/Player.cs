using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player{

    private string name;
    private string productionName;
    private int money;
    private int days;
    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
        }
    }

    public int Money
    {
        get
        {
            return money;
        }

        set
        {
            money = value;
        }
    }

    public int Days
    {
        get
        {
            return days;
        }

        set
        {
            days = value;
        }
    }

    public string ProductionName
    {
        get
        {
            return productionName;
        }

        set
        {
            productionName = value;
        }
    }
}
