using System.Collections;
using UnityEngine;

public class ObstackleManager : MonoBehaviour
{
    [SerializeField] private obstackle[] buildings = new obstackle[10];
    [SerializeField] private obstackle[] coins = new obstackle[10];
    [SerializeField] private obstackle[] boxes = new obstackle[10];
    [SerializeField] private road[] BuildingsRoad = new road[10];
    private int BuildingsCapacity = 10;
    private int CoinsCapacity = 10;
    private int BoxesCapacity = 10;
    private int BuildingsRoadCapacity = 10;
    IEnumerator enumerator() 
    {
        obstackle[] BuildingsBuffer = new obstackle[BuildingsCapacity];
        int BuildingsSize = 0;
        foreach (var ob in buildings) 
        {
            if (ob.IsFree) 
            { 
                BuildingsBuffer[BuildingsSize] = ob;
                BuildingsSize++;
            }
        }
        foreach (var ob in BuildingsRoad)
        {
            if(BuildingsSize == 0) 
            {
                break;
            }
            if (ob.IsFree) 
            {
                print(BuildingsSize);
                BuildingsBuffer[BuildingsSize - 1].Teleport(ob.transform.position);
                BuildingsSize--;
            }
        }
        yield return new WaitForSeconds(5);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BuildingsCapacity = buildings.Length;
        CoinsCapacity = coins.Length;
        BoxesCapacity = boxes.Length;
        BuildingsRoadCapacity = BuildingsRoad.Length;
        StartCoroutine(enumerator());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
