using System.Collections;
using UnityEngine;

public class ObstackleManager : MonoBehaviour
{
    [SerializeField] private obstackle[] buildings = new obstackle[10];
    [SerializeField] private obstackle[] coins = new obstackle[10];
    [SerializeField] private obstackle[] boxes = new obstackle[10];
    [SerializeField] private road[] BuildingsRoad = new road[10];
    [SerializeField] private road[] BoxesRoad = new road[10];
    [SerializeField] private road[] CoinsRoad = new road[10];
    private int BuildingsCapacity = 10;
    private int CoinsCapacity = 10;
    private int BoxesCapacity = 10;
    private int BuildingsRoadCapacity = 10;
    private int BoxesRoadCapacity = 10;
    private int CoinsRoadCapacity = 10;
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
    IEnumerator en()
    {
        obstackle[] BoxesBuffer = new obstackle[BoxesCapacity];
        int BoxesSize = 0;
        foreach (var ob in boxes)
        {
            if (ob.IsFree)
            {
                BoxesBuffer[BoxesSize] = ob;
                BoxesSize++;
            }
        }
        foreach (var ob in BoxesRoad)
        {
            if (BoxesSize == 0)
            {
                break;
            }
            if (ob.IsFree)
            {
                print(BoxesSize);
                BoxesBuffer[BoxesSize - 1].Teleport(ob.transform.position);
                BoxesSize--;
            }
        }
        yield return new WaitForSeconds(5);
    }
    IEnumerator enumer()
    {
        obstackle[] CoinsBuffer = new obstackle[CoinsCapacity];
        int CoinsSize = 0;
        foreach (var ob in coins)
        {
            if (ob.IsFree)
            {
                CoinsBuffer[CoinsSize] = ob;
                CoinsSize++;
            }
        }
        foreach (var ob in BoxesRoad)
        {
            if (CoinsSize == 0)
            {
                break;
            }
            if (ob.IsFree)
            {
                print(CoinsSize);
                CoinsBuffer[CoinsSize - 1].Teleport(ob.transform.position);
                CoinsSize--;
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
        //StartCoroutine(en());
        StartCoroutine(enumer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
