using TMPro;
using UnityEngine;

public class GameDashboard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI MoneyText;
    [SerializeField] private TextMeshProUGUI ScoreText;
    [SerializeField] private TextMeshProUGUI MaxScoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MoneyText.text = SaveSystem.Instance.gamedata.money.ToString();
        ScoreText.text = SaveSystem.Instance.gamedata.score.ToString();
        MaxScoreText.text = SaveSystem.Instance.gamedata.MaxScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        MoneyText.text = SaveSystem.Instance.gamedata.money.ToString();
        ScoreText.text = SaveSystem.Instance.gamedata.score.ToString();
        MaxScoreText.text = SaveSystem.Instance.gamedata.MaxScore.ToString();
    }
}
