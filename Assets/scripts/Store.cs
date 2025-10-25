using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Store : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI CoinText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CoinText.text = SaveSystem.Instance.gamedata.money.ToString();
    }
}
