using UnityEngine;
using System.IO;
public class SaveSystem
{
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
        Load();
    }
    public void Save() 
    {
        string json = gamedata.save(GlobalPath);
        Debug.Log(GlobalPath);
        File.WriteAllText(GlobalPath, json);
    }
    public void Load() 
    {
        gamedata.load(GlobalPath);
    }
}
