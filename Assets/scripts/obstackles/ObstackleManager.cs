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

    void PlaceObjects(obstackle[] obstackles, road[] triggers)
    {
        obstackle[] ObjectsBuffer = new obstackle[obstackles.Length];
        int BufferSize = 0;
        foreach (var ob in obstackles)
        {
            if (ob.IsFree)
            {
                ObjectsBuffer[BufferSize] = ob;
                BufferSize++;
            }
        }
        foreach (var ob in triggers)
        {
            if (BufferSize == 0)
            {
                break;
            }
            if (ob.IsFree)
            {
                print(BufferSize);
                ObjectsBuffer[BufferSize - 1].Teleport(ob.transform.position);
                BufferSize--;
            }
        }
    }

    IEnumerator enumerator() 
    {
        PlaceObjects(buildings, BuildingsRoad);
        PlaceObjects(coins, CoinsRoad);
        //PlaceObjects(boxes, BoxesRoad);

        yield return new WaitForSeconds(5);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(enumerator());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
