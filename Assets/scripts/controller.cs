using DG.Tweening;
using UnityEngine;

public class controller : MonoBehaviour
{
    [SerializeField] private swipesystem ss;
    private int ActiveRoad = 1;
    [SerializeField] private float MoveDistance = 2f;
    [SerializeField] private float MoveDuration = 0.5f;
    [SerializeField] private float MoveDelay = 0.3f;
    private bool isMoving = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ss.RightEvent += Right;
        ss.LeftEvent += Left;
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
}
