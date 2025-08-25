using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public float Difficult { get; private set; }

    void ChangeDifficult() 
    {
        float score = SaveSystem.Instance.gamedata.score;
        Difficult = 1f + Mathf.Pow(score / 100f, 2f);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
