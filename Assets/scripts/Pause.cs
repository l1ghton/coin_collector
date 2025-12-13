using UnityEngine;

public class PauseData
{
    public static bool Pause
    {
        get { return pause; }
        set
        {
            if (pause != value)
            {
                if (value == true)
                {
                    PauseEnabled?.Invoke();
                }
                else { PauseDisabled?.Invoke(); }
                pause = value;

                PauseDisabled?.Invoke();
            }
        }
    }
    private static bool pause = false;
    public delegate void notify();
    public static event notify PauseDisabled;
    public static event notify PauseEnabled;
}
public class Pause : MonoBehaviour 
{
    void Start()
    {
        PauseData.Pause = false;
    }
    public void PauseChanger()
    {
       PauseData.Pause = !PauseData.Pause;
    }
}
