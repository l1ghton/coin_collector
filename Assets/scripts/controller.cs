using DG.Tweening;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class controller : MonoBehaviour
{
    [SerializeField] private swipesystem ss;
    private int ActiveRoad = 1;
    [SerializeField] private float MoveDistance = 2f;
    [SerializeField] private float MoveDuration = 0.5f;
    [SerializeField] private float MoveDelay = 0.3f;
    [SerializeField] private AudioManager audio;
    private bool isMoving = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ss.RightEvent += Right;
        ss.LeftEvent += Left;
        SaveSystem.Instance.Load();
        StartCoroutine(ScoreIncrenment());
    }

    // Update is called once per frame
    void Update()
    {

    }
    void Right() 

    {
        bool CanMove = ActiveRoad + 1 <= 2 && !isMoving;
        if (CanMove) 
        {
            ActiveRoad += 1;
            isMoving = true;
            transform.DOMoveZ(transform.position.z - MoveDistance, MoveDuration)
            .SetDelay(MoveDelay)
            .OnComplete(() => isMoving = false);
        }
    }
    void Left() 
    {
        bool canMove = ActiveRoad - 1 >= 0 && !isMoving;
        if (canMove)
        {
            ActiveRoad -= 1;
            isMoving = true;
            transform.DOMoveZ(transform.position.z + MoveDistance, MoveDuration)
            .SetDelay(MoveDelay)
            .OnComplete(() => isMoving = false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("RespawnCoin")) 
        {
            SaveSystem.Instance.gamedata.money += 1;
            SaveSystem.Instance.gamedata.score += 1;
            other.transform.GetComponent<coin>().release();
            SaveSystem.Instance.Save();
            audio.coin();
        }
        if (other.transform.CompareTag("Boxes")) 
        {
            audio.boxes();
        }
    }
    IEnumerator ScoreIncrenment() 
    {
        while (true)
        {
            SaveSystem.Instance.gamedata.score++;
            yield return new WaitForSeconds(1);
        }
    }
}
