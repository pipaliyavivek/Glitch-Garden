using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
   
    AudioSource M_audioSource;
    void Start()
    {
        DontDestroyOnLoad(this );
        M_audioSource = GetComponent<AudioSource>();
        M_audioSource.volume = PlayerPrefController.GetMasterVolume();
    }

    public void SetVolume(float volume)
    {
        M_audioSource.volume = volume;
    }

    
}
