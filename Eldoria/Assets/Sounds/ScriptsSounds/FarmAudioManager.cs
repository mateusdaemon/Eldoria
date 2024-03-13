using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmAudioManager : MonoBehaviour
{
    [Header("----Audio Source----")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("----Audio Clip----")]
    public AudioClip backgroundFarm;
    public AudioClip birds;

    private void Start()
    {
        musicSource.clip = backgroundFarm;
        musicSource.Play();
        sfxSource.clip = birds;
        sfxSource.Play();
    }
}
