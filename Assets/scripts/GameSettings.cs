using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using System.IO;

public class GameSettings
{
    public float volume;
    public float music;
    public float SFX;
    public float Difficult { get; private set; }

    public void ChangeDifficult() 
    {
        float score = SaveSystem.Instance.gamedata.score;
        Difficult = 1f + Mathf.Pow(score / 100f, 2f);
    }
    public string save(string GlobalPath)
    {
        string jsonn = JsonUtility.ToJson(this);
        return jsonn;
    }

    public void load(string GlobalPath)
    {
        if (File.Exists(GlobalPath))
        {
            string json = File.ReadAllText(GlobalPath);
            JsonUtility.FromJsonOverwrite(json, this);
        }
    }

}
