using UnityEngine;

public class city : obstackle
{
    protected override void move()
    {
        if (IsFree == false)
        {
            transform.position += ObstackleMoving * Time.deltaTime * Speed * SaveSystem.Instance.gamesettings.Difficult;
        }
    }
    public override void Teleport(Vector3 position, int RoadIndex)
    {
        if (RoadIndex == 0) 
        {
            Vector3 rote = transform.eulerAngles;
            rote.y = 0;
            transform.eulerAngles = rote;
        }
        else
        {
            Vector3 rote = transform.eulerAngles;
            rote.y = 180;
            transform.eulerAngles = rote;
        }
            transform.position = position + offset;
        IsFree = false;
    }
    protected override void TriggerEvent(GameObject other)
    {
        if (other.CompareTag("RespawnCity"))
        {
            IsFree = true;
        }
    }
}