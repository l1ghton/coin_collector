using UnityEngine;

public abstract class obstackle : MonoBehaviour
{
    protected float Speed = 75f;
    public bool IsFree { get; protected set; } = false;

    protected Vector3 ObstackleMoving = Vector3.left;
    public void Teleport(Vector3 position)
    {
        transform.position = position;
        IsFree = false;
    }
    protected abstract void move();

    // Update is called once per frame
    protected void Update()
    {
        move();
    }
    protected abstract void TriggerEvent(GameObject other);
    void OnTriggerEnter(Collider other)
    {
        TriggerEvent(other.gameObject);
    }
}
