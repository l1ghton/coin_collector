using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : Buttons
{
    protected override void ClickEvent()
    {
        SceneManager.LoadScene("main menu");
    }
}
