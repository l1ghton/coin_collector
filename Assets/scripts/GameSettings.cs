using UnityEngine;

public class GameSettings
{
    public float Difficult { get; private set; }

    public void ChangeDifficult() 
    {
        float score = SaveSystem.Instance.gamedata.score;
        Difficult = 1f + Mathf.Pow(score / 100f, 2f);
    }
}
