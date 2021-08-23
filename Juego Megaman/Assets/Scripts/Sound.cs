using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    AudioSource source;
    AudioMixerGroup mixerGroup;

    [SerializeField]
    public string name;
    [SerializeField]
    AudioClip clip;

    [SerializeField, Range(0.0F, 1.0F)]
    float volume = 0.7F;

    [SerializeField, Range(0.0F, 1.5F), Tooltip("Pitch is a quality that makes a melody go higher or lower.")]
    float pitch = 1.0F;

    [SerializeField]
    bool useRandomness = false;
    [SerializeField, Range(0.0F, 0.5F)]
    float randomVolume = 0.0F;
    [SerializeField, Range(0.0F, 0.5F)]
    float randomPitch = 0.0F;

    [SerializeField]
    bool loop;

    public void SetSource(AudioSource source)
    {
        this.source = source;
        source.clip = clip;
    }

    public void SetSource(AudioSource source, AudioMixerGroup mixerGroup)
    {
        SetSource(source);
        this.mixerGroup = mixerGroup;
    }

    public void Play()
    {
        if (useRandomness)
        {
            source.volume = volume * (1 + Random.Range(-randomVolume / 2.0F, randomVolume / 2.0F));
            source.pitch = pitch * (1 + Random.Range(-randomPitch / 2.0F, randomPitch / 2.0F)); ;
        }
        else
        {
            source.volume = volume;
            source.pitch = pitch;
        }

        if (mixerGroup)
        {
            source.outputAudioMixerGroup = mixerGroup;
        }

        source.loop = loop;
        source.Play();
    }

    public void Stop()
    {
        if (source.isPlaying)
        {
            source.Stop();
        }
    }

    public bool IsPlaying()
    {
        return source.isPlaying;
    }
}
