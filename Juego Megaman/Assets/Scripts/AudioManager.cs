using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField]
    AudioMixerGroup audioMixer;

    [SerializeField]
    Sound[] sounds;

    void Start()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            Sound sound = sounds[i];
            GameObject go = new GameObject($"Sound_{i}");
            go.transform.SetParent(transform);
            AudioSource audioSource = go.AddComponent<AudioSource>();
            sound.SetSource(audioSource, audioMixer);
        }
    }

    Sound FindSound(string name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            Sound sound = sounds[i];
            if (sound.name.Equals(name, System.StringComparison.OrdinalIgnoreCase))
            {
                return sound;
            }
        }

        return null;
    }

    public void PlaySound(string name)
    {
        Sound sound = FindSound(name);
        if (sound != null)
        {
            sound.Play();
        }
    }

    public void StopSound(string name)
    {
        Sound sound = FindSound(name);
        if (sound != null)
        {
            sound.Stop();
        }
    }

    public bool IsPlayingSound(string name)
    {
        Sound sound = FindSound(name);
        if (sound != null)
        {
            return sound.IsPlaying();
        }

        return false;
    }
}
