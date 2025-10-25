using UnityEngine;
using System.IO;
using System.Collections.Generic;
[System.Serializable]
public class SkinValue 
{
    public SkinStatus status;
    public Color color;
    public SkinValue(Color color)
    {
        this.status = SkinStatus.NotBuying;
        this.color = color;
    }
}

[System.Serializable]
public enum SkinStatus
{
    NotBuying,  // не куплен
    Bought,     // куплен
    Selected    // выбран
}

[System.Serializable]
public class SkinEntry
{
    public string key;
    public SkinValue value;
}

[System.Serializable]
public class GameData
{
    [SerializeField] private List<SkinEntry> skinsList = new List<SkinEntry>();

    // Реальный словарь (не сериализуется напрямую)
    public Dictionary<string, SkinValue> skins = new Dictionary<string, SkinValue>
    {
        {"Blue", new SkinValue(Color.blue)},
        {"Red", new SkinValue(Color.red)},
        {"Green", new SkinValue(Color.green)},
        {"Yellow", new SkinValue(Color.yellow)},
        {"Pink",new SkinValue(Color.pink)},
        {"Orange", new SkinValue(Color.orange)},
    };

    public int money;
    public int score;
    public int MaxScore;

    public string save(string GlobalPath)
    {
        SyncSkinsToList();

        if (File.Exists(GlobalPath))
        {
            string json = File.ReadAllText(GlobalPath);
            GameData gamedata = JsonUtility.FromJson<GameData>(json);

            if (score <= gamedata.score)
            {
                gamedata.money = money;
                gamedata.skinsList = skinsList;
                json = JsonUtility.ToJson(gamedata);
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
            SyncListToSkins();
            score = 0;
            Debug.Log(MaxScore);
        }
    }

    private void SyncSkinsToList()
    {
        skinsList.Clear();
        foreach (var kvp in skins)
        {
            skinsList.Add(new SkinEntry { key = kvp.Key, value = kvp.Value });
        }
    }

    private void SyncListToSkins()
    {
        skins.Clear();
        foreach (var entry in skinsList)
        {
            if (!skins.ContainsKey(entry.key))
                skins.Add(entry.key, entry.value);
        }
    }
}
