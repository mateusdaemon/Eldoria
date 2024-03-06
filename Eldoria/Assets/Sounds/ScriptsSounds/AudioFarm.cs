using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFarm : MonoBehaviour
{
    [Header("----Audio Source----")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("----Audio Clip----")]
    public AudioClip backgroundFarm;

    private void Start()
    {
        musicSource.clip = backgroundFarm;
        musicSource.Play();
    }
}
