using UnityEngine;

public class box : obstackle
{
    protected override void move()
    {
        if (IsFree == false)
        {
            transform.position += ObstackleMoving * Time.deltaTime * Speed * SaveSystem.Instance.gamesettings.Difficult;
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
