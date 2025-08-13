using UnityEngine;

public class road : MonoBehaviour
{
    public bool IsFree = true;
    private int Count;
    private void OnTriggerEnter(Collider other)
    {
        Count++;
    }
    private void OnTriggerExit(Collider other)
    {
        Count--;
    }
    void FixedUpdate()
    {
        if (Count == 0) 
        {
            IsFree = true;
        }
        else
        {
            IsFree = false;
        }

    }
}
