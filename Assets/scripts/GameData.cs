using UnityEngine;

public class GameData
{
    public int money;
    public int score;
    private static GameData instance;
    public static GameData Instance 
    { get 
        {
            if (instance == null) 
            {
                instance = new GameData();
            }
            return instance;
        } 
    }
}
