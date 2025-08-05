using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : Buttons
{
    protected override void ClickEvent()
    {
        SceneManager.LoadScene("game");
    }
}