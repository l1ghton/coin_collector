using UnityEngine;

public class road : MonoBehaviour
{
    public bool IsFree = true;
    private int Count;
    private void OnTriggerEnter(Collider other)
    {
        Count++;
        IsFree = false;
    }
    private void OnTriggerExit(Collider other)
    {
        Count--;

        if (Count == 0)
        {
            IsFree = true;
        }
    }
}
