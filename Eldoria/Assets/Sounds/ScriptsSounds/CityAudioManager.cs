using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityAudioManager : MonoBehaviour
{
    [Header("----Audio Source----")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("----Audio Clip----")]
    public AudioClip backgroundCity;


    private void Start()
    {
        musicSource.clip = backgroundCity;
        musicSource.Play();

    }
}
