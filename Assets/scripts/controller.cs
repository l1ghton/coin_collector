using UnityEngine;

public class controller : MonoBehaviour
{
    [SerializeField] private swipesystem ss;
    private int ActiveRoad = 1;
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
        if (ActiveRoad + 1 <= 2) 
        {
            ActiveRoad += 1;
            Vector3 currentPosition = transform.position;
            currentPosition += new Vector3(0, 0, -20);
            transform.position = currentPosition;
        }
    }
    void Left() 
    {
        print(ActiveRoad);
        if (ActiveRoad - 1 >= 0)
        {
            ActiveRoad -= 1;
            Vector3 currentPosition = transform.position;
            currentPosition += new Vector3(0, 0, 20);
            transform.position = currentPosition;
        }
    }
}
