using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : Buttons
{
    protected override void ClickEvent()
    {
        if (tween != null && tween.IsActive())
        {
            tween.Kill();
        }
        SceneManager.LoadScene("game");
    }
}