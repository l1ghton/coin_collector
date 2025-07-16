using UnityEngine;

public class coin : obstackle
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
        if (other.CompareTag("RespawnCoin"))
        {
            IsFree = true;
        }
    }
}