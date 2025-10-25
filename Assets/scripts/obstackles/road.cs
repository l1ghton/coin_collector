using UnityEngine;

public class road : MonoBehaviour
{
    public bool IsFree = true;
    public int Count;
    private void OnTriggerEnter(Collider other)
    {
        print(transform.name + " " + other.name);
        Count++;
        IsFree = false;
    }
    private void OnTriggerExit(Collider other)
    {
        Count--;

    }
    private void FixedUpdate()
    {
        if (Count == 0)
        {
            IsFree = true;
        }
    }
}
