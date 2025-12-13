using UnityEngine;
using System.IO;
public class SaveSystem
{
    private string GlobalPath2;
    private string FileName2 = "SettingsSave.json";
    private string FileName = "Save.json";
    private string GlobalPath;
    private static SaveSystem instance;
    public GameData gamedata = new GameData();
    public GameSettings gamesettings = new GameSettings();
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
        GlobalPath2 = Application.persistentDataPath + "/" + FileName2;
        Load();
    }
    public void Save() 
    {
        string json = gamedata.save(GlobalPath);
        Debug.Log(GlobalPath);
        File.WriteAllText(GlobalPath, json);
        string jsonn = gamesettings.save(GlobalPath);
        File.WriteAllText(GlobalPath2, jsonn);
    }
    public void Load() 
    {
        gamedata.load(GlobalPath);
        gamesettings.load(GlobalPath2);
    }
}
