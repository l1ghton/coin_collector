using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitMarketButton : Buttons
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
