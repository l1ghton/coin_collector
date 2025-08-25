using UnityEngine;
[System.Serializable] public struct music_volume 
{
    public AudioClip music;
   [Range(0,1)] public float volume;
}
public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource coin_sound;
    [SerializeField] private AudioSource music;
    [SerializeField] private AudioSource box_sound;
    [SerializeField] music_volume[] audioclip;
    private int sound_index;
    public void coin() 
    {
        coin_sound.Play();
    }
    public void boxes()
    {
        box_sound.Play();
    }
    private void PlaySound() 
    {
        if (music.isPlaying) 
        {
            return;
        }
        if (sound_index + 1 < audioclip.Length) 
        {
            sound_index++;
        }
        else 
        {
            sound_index = 0;
        }
        music.clip = audioclip[sound_index].music;
        music.volume = audioclip[sound_index].volume;
        music.Play();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        PlaySound();
    }
}
