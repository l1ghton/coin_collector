using UnityEngine;

public class SkinManager : MonoBehaviour
{
    [SerializeField] private skin[] allSkins;
    public void skinupdate() 
    {
        foreach (var sk in allSkins) 
        {
            sk.ChangeSkinStatus();
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
