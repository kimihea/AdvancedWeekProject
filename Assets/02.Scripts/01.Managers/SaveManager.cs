using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;


[System.Serializable]
public class GameData
{
    public int Gold;
    public CharacterStatHandler stat;
    public int nowStage;

    public GameData()
    {
        stat = new CharacterStatHandler();
    }
}
public class SaveManager : MonoBehaviour
{
    string path;
    public void Initializer()
    {
        path = Path.Combine(Application.dataPath, "gameData.json");
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
