using UnityEngine;

public class box : obstackle
{
    protected override void move()
    {
        if (IsFree == false)
        {
            transform.position += ObstackleMoving * Time.deltaTime * Speed;
        }
    }
    protected override void TriggerEvent(GameObject other) 
    {
        if (other.CompareTag("Respawn"))
        {
            IsFree = true;
        }
    }
}
