using TMPro;
using UnityEngine;

public class GameDashboard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI MoneyText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MoneyText.text = GameData.Instance.money.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        MoneyText.text = GameData.Instance.money.ToString();
    }
}
