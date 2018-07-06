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
        Debug.Log(Application.persistentDataPath);
        SaveData data = new SaveData(savenum,player, character);

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
        for (int i = 1; i <= 5; i++)
        {
            if (File.Exists(Application.persistentDataPath + "/save" + i + ".sav"))
            {
                saveDatas.Add(loadData(i));
            }
            else
            {
                saveDatas.Add(null);
            }
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
    public string saveTime;
    public int saveIndex;
    public SaveData(int index,Player player,Character character)
    {
        this.name = player.Name;
        this.productionName = player.ProductionName;
        this.money = player.Money;
        this.days = player.Days;
        this.characterStrings = character.GetStrings();
        this.characterInt = character.GetInts();
        saveTime = System.DateTime.Now.ToString("MMMM dd, yyyy H:mm:ss");
        saveIndex = index;
        Debug.Log(saveTime);
    }
    public Character GetCharacter()
    {
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
        Character temp = new Character();
        temp.FirstName = characterStrings[0];
        temp.LastName = characterStrings[1];
        temp.StageName = characterStrings[2];
        temp.Fiery = characterInt[0];
        temp.Coolish = characterInt[1];
        temp.Calming = characterInt[2];
        temp.Vocal = characterInt[3];
        temp.Expression = characterInt[4];
        temp.Dance = characterInt[5];
        temp.Confidence = characterInt[6];
        temp.Ethic = characterInt[7];
        temp.Social = characterInt[8];
        temp.CurrentStamina = characterInt[9];
        temp.MaxStamina = characterInt[10];
        temp.Motivation = characterInt[11];
        temp.Health = characterInt[12];
        temp.Popularity = characterInt[13];
        return temp;
    }
    public Player GetPlayer()
    {
        Player temp = new Player();
        temp.Name = name;
        temp.ProductionName = productionName;
        temp.Days = days;
        temp.Money = money;
        return temp;
    }
}
