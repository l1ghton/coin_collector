using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : Buttons
{
    protected override void ClickEvent()
    {
        if (tween != null && tween.IsActive()) 
        {
            tween.Kill();
        }
        SceneManager.LoadScene("main menu");
    }
}
