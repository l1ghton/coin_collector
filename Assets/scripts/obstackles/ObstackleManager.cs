using System.Collections;
using System.Linq;
using UnityEngine;

public class ObstackleManager : MonoBehaviour
{
    [SerializeField] private GameObject coin;
    [SerializeField] private GameObject box;
    [SerializeField] private GameObject building;
    private obstackle[] buildings = new obstackle[10];
    private obstackle[] coins = new obstackle[10];
    private obstackle[] boxes = new obstackle[10];
    [SerializeField] private road[] BuildingsRoad = new road[10];
    [SerializeField] private road[] BoxesRoad = new road[10];
    [SerializeField] private road[] CoinsRoad = new road[10];
    private int generation;

    void PlaceObjects(obstackle[] obstackles, road[] triggers, int count = int.MaxValue)
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
        for (int i = BufferSize - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            var temp = ObjectsBuffer[i];
            ObjectsBuffer[i] = ObjectsBuffer[j];
            ObjectsBuffer[j] = temp;
        }
        for (int i = 0;i < triggers.Length; i++)
        {
            var ob = triggers[i];
            if (BufferSize == 0)
            {
                break;
            }
            if (ob.IsFree)
            {
                if (!(count - 1 >= 0)) {return;}
                count--;
                ob.IsFree = false;
                ObjectsBuffer[BufferSize - 1].Teleport(ob.transform.position, i);
                BufferSize--;
            }
        }
    }

    IEnumerator enumerator() 
    {
        while (true)
        {
            generation = Random.Range(1, 3);
            if (Random.Range(0, 2) == 0) 
            {
                PlaceObjects(coins, CoinsRoad, generation);
                PlaceObjects(boxes, BoxesRoad, generation);
            }
            else 
            {
                PlaceObjects(boxes, BoxesRoad, generation);
                PlaceObjects(coins, CoinsRoad, generation);
            }

            yield return new WaitForSeconds(2);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boxes = new obstackle[box.transform.childCount];
        for (int i = 0; i < boxes.Length; i++) 
        {
            boxes[i] = box.transform.GetChild(i).GetComponent<obstackle>();
        }
        coins = new obstackle[coin.transform.childCount];
        for (int i = 0;i < coins.Length; i++) 
        {
            coins[i] = coin.transform.GetChild(i).GetComponent<obstackle>();
        }
        buildings = new obstackle[building.transform.childCount];
        for (int i = 0; i < buildings.Length; i++)
        {
            buildings[i] = building.transform.GetChild(i).GetComponent<obstackle>();
        }
        StartCoroutine(enumerator());
    }

    // Update is called once per frame
    void Update()
    {
        PlaceObjects(buildings, BuildingsRoad);
    }
}
