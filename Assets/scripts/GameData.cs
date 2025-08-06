using UnityEngine;
using System.IO;
[System.Serializable]
public class GameData
{
    public string save(string GlobalPath) 
    {
        if (File.Exists(GlobalPath))
        {
            string json = File.ReadAllText(GlobalPath);
            GameData gamedata = JsonUtility.FromJson<GameData>(json);

            if (score <= gamedata.score) 
            {
                return json;
            }
        }
        MaxScore = score;
        string jsonn = JsonUtility.ToJson(this);
        return jsonn;
    }
    public void load(string GlobalPath) 
    {
        if (File.Exists(GlobalPath))
        {
            string json = File.ReadAllText(GlobalPath);
            JsonUtility.FromJsonOverwrite(json, this);
            score = 0;
        }
    }
    public int money;
    public int score;
    public int MaxScore
    {
        get;
        private set;
    }
}
