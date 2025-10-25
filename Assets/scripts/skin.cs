using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class skininfo
{
    public SkinStatus status;
    public string skinName;
    public int price;
}
public class skin : MonoBehaviour
{
    [SerializeField] private SkinManager skinmanager;
    [SerializeField] private Image bought;
    [SerializeField] private skininfo skininfo;
    private Color[] color = new Color[3]
    {
        Color.red, Color.green, Color.blue,
    };
    private void Start()
    {
        ChangeSkinStatus();
    }
    public void ChangeSkinStatus() 
    {
        if (!SaveSystem.Instance.gamedata.skins.ContainsKey(skininfo.skinName))
        {
            return;
        }
        skininfo.status = SaveSystem.Instance.gamedata.skins[skininfo.skinName].status;
        bought.color = color[(int)skininfo.status];
    }
    public void buy()
    {
        print(transform.name);
        if (skininfo.price > SaveSystem.Instance.gamedata.money)
        {
            return;
        }

        if (!SaveSystem.Instance.gamedata.skins.ContainsKey(skininfo.skinName))
        {
            return;
        }
        if (SaveSystem.Instance.gamedata.skins[skininfo.skinName].status != SkinStatus.NotBuying)
        {
            for(int skinID = 0; skinID < SaveSystem.Instance.gamedata.skins.Count; skinID++) 
            {
                var skin = SaveSystem.Instance.gamedata.skins.ElementAt(skinID);
                if (skin.Value.status == SkinStatus.Selected) 
                {
                    SaveSystem.Instance.gamedata.skins[skin.Key].status = SkinStatus.Bought;
                }
            }
            SaveSystem.Instance.gamedata.skins[skininfo.skinName].status = SkinStatus.Selected;
            SaveSystem.Instance.Save();
            skinmanager.skinupdate();
        }
        else 
        {
            SaveSystem.Instance.gamedata.money -= skininfo.price;
            SaveSystem.Instance.gamedata.skins[skininfo.skinName].status = SkinStatus.Bought;
            SaveSystem.Instance.Save();
            ChangeSkinStatus();
        }
    }
}
