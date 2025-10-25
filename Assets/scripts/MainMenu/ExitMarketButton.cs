using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitMarketButton : Buttons
{
    protected override void ClickEvent()
    {
        SceneManager.LoadScene("main menu");
    }
}
