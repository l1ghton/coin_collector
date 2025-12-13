using DG.Tweening;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;

public class controller : MonoBehaviour
{
    [SerializeField] private swipesystem ss;
    private int ActiveRoad = 1;
    [SerializeField] private float MoveDistance = 2f;
    [SerializeField] private float MoveDuration = 0.5f;
    [SerializeField] private float MoveDelay = 0.3f;
    [SerializeField] private AudioManager audio;
    private bool isMoving = false;
    [SerializeField] private Material Material;
    [SerializeField] private Tween anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var skin = SaveSystem.Instance.gamedata.skins.FirstOrDefault(x => x.Value.status == SkinStatus.Selected).Key;
        if (skin == null || skin == "") 
        {
            Material.color = Color.white;
        }
        else
        {
            Material.color = SaveSystem.Instance.gamedata.skins[skin].color;
        }
            ss.RightEvent += Right;
        ss.LeftEvent += Left;
        SaveSystem.Instance.Load();
        StartCoroutine(ScoreIncrenment());
        PauseData.PauseDisabled += PauseDisabled;
        PauseData.PauseEnabled += PauseEnabled;
    }

    // Update is called once per frame
    void Update()
    {
        SaveSystem.Instance.gamesettings.ChangeDifficult();
    }
    void Right() 

    {
        bool CanMove = ActiveRoad + 1 <= 2 && !isMoving;
        if (CanMove && PauseData.Pause == false) 
        {
            ActiveRoad += 1;
            isMoving = true;
            anim = transform.DOMoveZ(transform.position.z - MoveDistance, MoveDuration)
            .SetDelay(MoveDelay)
            .OnComplete(() => isMoving = false);
        }
        if (PauseData.Pause == true && anim != null && anim.IsPlaying()) 
        {
            anim.Pause();
        }
    }
    void Left() 
    {
        bool canMove = ActiveRoad - 1 >= 0 && !isMoving;
        if (canMove && PauseData.Pause == false)
        {
            ActiveRoad -= 1;
            isMoving = true;
            anim = transform.DOMoveZ(transform.position.z + MoveDistance, MoveDuration)
            .SetDelay(MoveDelay)
            .OnComplete(() => isMoving = false);
        }
    }
    public void PauseDisabled() 
    {
        if (anim != null && anim.IsActive()) 
        {
            anim.Play();
        }
    }
    public void PauseEnabled() 
    {
        if (anim != null && anim.IsActive() && anim.IsPlaying())
        {
            anim.Pause();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("RespawnCoin")) 
        {
            SaveSystem.Instance.gamedata.money += 1;
            SaveSystem.Instance.gamedata.score += 1;
            other.transform.GetComponent<coin>().release();
            SaveSystem.Instance.Save();
            audio.coin();
        }
        if (other.transform.CompareTag("Boxes")) 
        {
            audio.boxes();
        }
    }
    IEnumerator ScoreIncrenment() 
    {
        while (true)
        {
            SaveSystem.Instance.gamedata.score++;
            yield return new WaitForSeconds(1);
        }
    }
    private void OnDestroy()
    {
        anim?.Kill();
    }
}