using System.Collections.Generic;
using UnityEngine;

public abstract class obstackle : MonoBehaviour
{
    protected float Speed = 75f;
    public bool IsFree { get; protected set; } = true;

    protected Vector3 ObstackleMoving = Vector3.left;

    [SerializeField] protected List<Vector3> tf = new List<Vector3>();
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
