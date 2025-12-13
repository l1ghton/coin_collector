using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class volume : MonoBehaviour
{
    public Slider VolumeSlider;
    public Slider MusicSlider;
    public Slider SFXslider;
    public AudioMixer mixer;
    public void Reset()
    {
        mixer.SetFloat("Master", 0);
        mixer.SetFloat("music", 0);
        mixer.SetFloat("SFX", 0);
        SaveSystem.Instance.gamesettings.volume = 0;
        SaveSystem.Instance.gamesettings.music = 0;
        SaveSystem.Instance.gamesettings.SFX = 0;
        VolumeSlider.value = 0;
        MusicSlider.value = 0;
        SFXslider.value = 0;
        SaveSystem.Instance.Save();
    }
    void Start()
    {
        SaveSystem.Instance.Load();
        mixer.SetFloat("Master", SaveSystem.Instance.gamesettings.volume);
        mixer.SetFloat("music", SaveSystem.Instance.gamesettings.music);
        mixer.SetFloat("SFX", SaveSystem.Instance.gamesettings.SFX);
        VolumeSlider.value = SaveSystem.Instance.gamesettings.volume;
        MusicSlider.value = SaveSystem.Instance.gamesettings.music;
        SFXslider.value = SaveSystem.Instance.gamesettings.SFX;
    }
    public void Volume(float value) 
    {
        mixer.SetFloat("Master", value);
        SaveSystem.Instance.gamesettings.volume = value;
        SaveSystem.Instance.Save();
    }
    public void music(float value)
    {
        mixer.SetFloat("music", value);
        SaveSystem.Instance.gamesettings.music = value;
        SaveSystem.Instance.Save();
    }
    public void SFX(float value)
    {
        mixer.SetFloat("SFX", value);
        SaveSystem.Instance.gamesettings.SFX = value;
        SaveSystem.Instance.Save();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
