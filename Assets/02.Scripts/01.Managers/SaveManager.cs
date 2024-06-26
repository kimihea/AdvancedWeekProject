using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;


[System.Serializable]
public class GameData
{
    public int Gold;
    public int nowStage;
    public float fatigue;
    public float maxFatigue;
    public GameData()
    {
        Gold = 0;
        nowStage = 0;
        fatigue = 0;
        maxFatigue = 100;
    }   
}
public class SaveManager : MonoBehaviour
{
    string path;
    public void Initializer(GameData data)
    {
        path = Path.Combine(Application.dataPath, "gameData.json");
        SaveData(data);
    }
    public void SaveData(GameData data)
    {
        string jsonData = JsonConvert.SerializeObject(data);
        File.WriteAllText(path, jsonData);
    }
    public bool TryLoadData(out GameData data)
    {
        if(File.Exists(path))
        {
            string jsonData = File.ReadAllText(path);
            data = JsonConvert.DeserializeObject<GameData>(jsonData);
            return true;
        }
        else
        {
            data = null;
            return false;
        }
    }
}
