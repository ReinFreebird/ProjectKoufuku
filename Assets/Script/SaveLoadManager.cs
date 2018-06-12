using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public static class SaveLoadManager{
    public static void saveData(Player player,Character character,int savenum)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = new FileStream(Application.persistentDataPath + "/save" + savenum + ".sav", FileMode.Create);

        SaveData data = new SaveData(player, character);

        bf.Serialize(file, data);
        file.Close();
    }
    public static SaveData loadData(int loadnum)
    {
        if (File.Exists(Application.persistentDataPath + "/save" + loadnum + ".sav"))
        {
            SaveData data;
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = new FileStream(Application.persistentDataPath + "/save" + loadnum + ".sav", FileMode.Open);

            data = bf.Deserialize(file) as SaveData;

            file.Close();
            return data;
        }
        else
        {
            return null;
        }
    }
    public static List<SaveData> GetSaveDatas()
    {
        List<SaveData> saveDatas = new List<SaveData>();
        for (int i = 1; i < 10; i++)
        {
            saveDatas.Add(loadData(i));
        }
        return saveDatas;
    }
	
}
[Serializable]
public class SaveData
{
    public string[] characterStrings;
    /*Index for characterStrings
     * 0=Character.FirstName
     * 1=Character.LastName
     * 2=Character.StageName
     */
    public int[] characterInt;
    /*Index for CharacterInt
     * 0= Fiery
     * 1= Coolish
     * 2= Calming
     * 3= Vocal
     * 4= Expression
     * 5= Dance
     * 6= Confidence
     * 7= Ethics
     * 8= Social
     * 9= CurrentStamina
     * 10= MaxStamina
     * 11= Motivation
     * 12= Health
     * 13= Popularity
     */
    public string name;
    public string productionName;
    public int money;
    public int days;

    public SaveData(Player player,Character character)
    {
        this.name = player.Name;
        this.productionName = player.ProductionName;
        this.money = player.Money;
        this.days = player.Days;
        this.characterStrings = character.GetStrings();
        this.characterInt = character.GetInts();
    }
}
