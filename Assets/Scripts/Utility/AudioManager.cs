using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;
    public Sound[] BGMSounds;

    // Start is called before the first frame update
    void Awake()
    {
        foreach(Sound s in sounds)
        {
            SetupSound(s);
        }
        foreach(Sound s in BGMSounds)
        {
            SetupSound(s);
        }
    }

    void Update()
    {
        BGM();
    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s != null)
        {
            if (!s.source.isPlaying)
            {
                s.source.Play();
            }
        }
        else
        {
            Debug.LogWarning("Sound with name " + name + " not found");
        }
    }

    public void PlayBGM(string name)
    {
        Sound s = Array.Find(BGMSounds, sound => sound.name == name);

        if (s != null)
        {
            if (!s.source.isPlaying)
            {
                s.source.Play();
            }
        }
        else
        {
            Debug.LogWarning("Sound with name " + name + " not found");
        }
    }

    public void BGM()
    {
        if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            
            PlayBGM("MainMenuBGM");
            PauseAll("MainMenuBGM");
        }
        else if (SceneManager.GetActiveScene().name == "Level 1")
        {
            PlayBGM("Level1BGM");
            PauseAll("Level1BGM");
        }
    }
    public void PauseAll(string soundToPlay)
    {
        foreach (Sound s in BGMSounds)
        {
            if(s.name != soundToPlay)
            {
                s.source.Stop();
            }
        }
    }

void SetupSound(Sound s)
{
    // Create an AudioSource component for each sound
    s.source = gameObject.AddComponent<AudioSource>();
    // Set the clip
    s.source.clip = s.clip;
    // Set the volume
    s.source.volume = s.volume;
    // Set the pitch
    s.source.pitch = s.pitch;
    // Set the loop
    s.source.loop = s.loop;
}
}

