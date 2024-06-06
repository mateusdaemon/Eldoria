using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    [Header("--- Audio Source ---")]
    public AudioSource musicSource;
    public AudioSource birdsSource;
    public AudioSource cricketSource;
    public AudioSource frogSource;
    public AudioSource sfxSource;
    public AudioSource walkSource;
    public AudioSource runSource;

    [Header("--- Music ---")]
    public AudioClip cityBackground;
    public AudioClip farmBackground;
    public AudioClip fightBackground;
    public AudioClip farmNightBackground;

    [Header("--- PlayerSFX ---")]
    public AudioClip sfxShooter;
    public AudioClip sfxShooterErro;
    public AudioClip sfxShield;
    public AudioClip sfxShieldErro;
    public AudioClip sfxShieldDestroy;
    public AudioClip sfxBreakCurse;
    public AudioClip sfxErroBreakCurse;
    public AudioClip sfxErroManaHeal;
    public AudioClip sfxDrinkLife;
    public AudioClip sfxDrinkMana;
    public AudioClip sfxDodge;
    public AudioClip sfxDodgeErro;
    public AudioClip sfxTakingDamage;
    public AudioClip sfxTakingShieldDamage;
    public AudioClip sfxWalk;
    public AudioClip sfxRun;


    [Header("--- Ambient ---")]
    public AudioClip windMillSound;
    public AudioClip chimneySound;
    public AudioClip sheepSound;
    public AudioClip birdSound;
    public AudioClip airSound;
    public AudioClip cricketSound;
    public AudioClip frogSound;

    [Header("--- Effects ---")]
    public AudioClip wolfBarkSound;
    public AudioClip sfxWolfDie;
    public AudioClip wolfhowl;
    public AudioClip boarHit;
    public AudioClip boarThreat;
    public AudioClip corn;

    public void PlaySfx(AudioClip clip)
    {
        if (sfxSource != null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }

    public void PlayWalk(AudioClip clip)
    {
        walkSource.PlayOneShot(clip);
    }

    public void PlayRun(AudioClip clip)
    {
        runSource.PlayOneShot(clip);
    }
    public void PlayFarm()
    {
        musicSource.clip = farmBackground;
        birdsSource.clip = birdSound;
        musicSource.Play();
        birdsSource.Play();
    }

    public void PlayFarmNight()
    {
        musicSource.clip = farmNightBackground;
        frogSource.clip = frogSound;
        musicSource.Play();
        frogSource.Play();
        Invoke("PlayCricketSound", 3);
    }

    public void PlayCricketSound()
    {
        cricketSource.clip = cricketSound;
        cricketSource.Play();
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Farm")
        {
            PlayFarm();
        }
        else if (SceneManager.GetActiveScene().name == "FarmNight")
        {
            PlayFarmNight();
            sfxSource.PlayOneShot(wolfhowl);
        }
    }
}
