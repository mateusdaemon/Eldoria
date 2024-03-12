using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightAudioManager : MonoBehaviour
{
    [Header("----Audio Source----")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("----Audio Clip----")]
    public AudioClip fightMusic;

    private void Start()
    {
        musicSource.clip = fightMusic;
        musicSource.Play();
    }
}
