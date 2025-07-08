using UnityEngine;

public class city : MonoBehaviour
{
    private Vector3 ObstackleMoving = Vector3.left;
    private float Speed = 75f;
    public bool IsFree { get; private set; } = false;
    public void Teleport(Vector3 position)
    {
        transform.position = position;
        IsFree = false;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    void move()
    {
        if (IsFree == false)
        {
            transform.position += ObstackleMoving * Time.deltaTime * Speed;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        print("y");
        if (other.CompareTag("RespawnCity"))
        {
            IsFree = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        move();
    }
}

