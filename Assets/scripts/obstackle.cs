using UnityEngine;

public class obstackle : MonoBehaviour
{
    private Vector3 ObstackleMoving = Vector3.left;
    public bool IsFree {get;private set;} = false;
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
            transform.position += ObstackleMoving;
        }
    }
    void OnCollisionStay(Collision other)
    {
        print("y");
        if (other.transform.tag == "Respawn") 
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
