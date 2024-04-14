using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    [Header("--- Audio Source ---")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource birdsSource;
    [SerializeField] AudioSource sfxSource;

    [Header("--- Music ---")]
    public AudioClip cityBackground;
    public AudioClip farmBackground;
    public AudioClip fightBackground;

    [Header("--- PlayerSFX ---")]
    public AudioClip sfxShooter;
    public AudioClip sfxShooterErro;
    public AudioClip sfxShield;
    public AudioClip sfxShieldErro;
    public AudioClip sfxBreakCurse;
    public AudioClip sfxErroBreakCurse;
    public AudioClip sfxErroManaHeal;
    public AudioClip sfxDrinkLife;
    public AudioClip sfxDrinkMana;
    public AudioClip sfxDodge;
    public AudioClip sfxDodgeErro;
    public AudioClip sfxTakingDamage;
    public AudioClip sfxWalk;
    

    [Header("--- Ambient ---")]
    public AudioClip windMillSound;
    public AudioClip chimneySound;
    public AudioClip sheepSound;
    public AudioClip birdSound;
    public AudioClip airSound;

    [Header("--- Effects ---")]
    public AudioClip wolfBarkSound;
    public AudioClip sfxWolfDie;

    public void PlaySfx(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void PlayFarm()
    {
        musicSource.clip = farmBackground;
        birdsSource.clip = birdSound;
        musicSource.Play();
        birdsSource.Play();
    }

    private void Start()
    {
        if(SceneManager.GetActiveScene().name == "Farm")
        {
            PlayFarm();
        }
    }
}
