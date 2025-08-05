using UnityEngine;
using System.IO;
public class SaveSystem
{
    private string FileName = "Save.json";
    private string GlobalPath;
    private static SaveSystem instance;
    public static SaveSystem Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new SaveSystem();
            }
            return instance;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    SaveSystem()
    {
        GlobalPath = Application.persistentDataPath + "/" + FileName;
        Load();
    }
    public void Save() 
    {
        string  json = JsonUtility.ToJson(GameData.Instance);
        File.WriteAllText(GlobalPath, json);
    }
    public void Load() 
    {
        if (File.Exists(GlobalPath)) 
        {
            Debug.Log(GlobalPath);
            string json = File.ReadAllText(GlobalPath);
            GameData gamedata = JsonUtility.FromJson<GameData>(json);
            GameData.Instance.money = gamedata.money;
        }
    }
}
