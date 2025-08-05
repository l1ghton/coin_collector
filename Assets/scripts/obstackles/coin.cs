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
    public void release() 
    {
        IsFree = true;
        transform.position = new Vector3(-444.3f, 26.44848f,0);
    }
}