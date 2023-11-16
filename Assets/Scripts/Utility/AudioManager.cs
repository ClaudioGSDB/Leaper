using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    // Start is called before the first frame update
    void Awake()
    {
        foreach(Sound s in sounds)
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
}
