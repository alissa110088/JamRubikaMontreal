using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    
    void Start()
    {
        Play("AMB_Factory");
        Play("AMB_Carpet");
        Play("AMB_Labubu");
        Play("AMB_Neon");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.outputAudioMixerGroup = s.audioMixerGroup;
        s.source.clip = s.clip;
        s.source.loop = s.loop;
        s.source.volume = s.volume;
        s.source.pitch = s.pitch;
        s.source.Play();
    }

    public void Stop()
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Stop();
    }
}
