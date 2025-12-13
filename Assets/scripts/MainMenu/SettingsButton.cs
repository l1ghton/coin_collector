using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsButton : Buttons
{
    protected override void ClickEvent() 
    {
        if (tween != null && tween.IsActive())
        {
            tween.Kill();
        }
        SceneManager.LoadScene("settings");
    }
}
