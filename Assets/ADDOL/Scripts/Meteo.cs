using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Meteo
{
    public List<Weather> weather;

    private static Meteo inst;
    public static Meteo Inst
    {
        get
        {
            if (inst == null)
            {
                inst = new Meteo();
            }
            return inst;
        }
    }

    public void UpdateValuesFromJSON(string jsonString)
    {
        JsonUtility.FromJsonOverwrite(jsonString, Inst);
    }
}

[System.Serializable]
public class Weather
{
    public int id;
    public string main;
    public string description;
    public string icon;
}
