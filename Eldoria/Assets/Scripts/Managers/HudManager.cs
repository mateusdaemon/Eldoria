using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    [Header("Player Stats")]
    public Image lifeBar;
    public Image manaBar;

    [Header("Potions")]
    public Image lifePot;
    public Image lifePotShine;
    public Image manaPot;
    public Image manaPotShine;

    [Header("Quests")]
    public TextMeshProUGUI questText;

    [Header("Books")]
    public Image neutralSelect;

    [Header("Skills")]
    public Image shoot;
    public Image shootBright;
    public Image shield;
    public Image shieldBright;
    public Image dodge;
    public Image dodgeBright;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLifeAmout(float amount)
    {
        lifeBar.fillAmount = amount;
    }

    public void SetManaAmount(float amount)
    {
        manaBar.fillAmount = amount;
    }

    public void ActivateLifePot()
    {
        lifePot.fillAmount = 1;
        lifePotShine.enabled = true;
    }

    public void ActivateManaPot()
    {
        manaPot.fillAmount = 1;
        manaPotShine.enabled = true;
    }

    public void UseLifePot()
    {
        lifePot.fillAmount = 0;
        lifePotShine.enabled = false;
    }

    public void UseManaPot()
    {
        manaPot.fillAmount = 0;
        manaPotShine.enabled = false;
    }

    public void SetQuestText(string text)
    {
        questText.text = text;
    }

    public void ActivateShootSkill()
    {
        shoot.fillAmount = 1;
        shootBright.enabled = true;
    }

    public void UseShootSkill()
    {
        shoot.fillAmount = 0;
        shootBright.enabled = false;
    }

    public void ActivateShieldSkill()
    {
        shield.fillAmount = 1;
        shieldBright.enabled = true;
    }

    public void UseShieldSkill()
    {
        shield.fillAmount = 0;
        shieldBright.enabled = false;
    }

    public void ActivateDodgeSkill()
    {
        dodge.fillAmount = 1;
        dodgeBright.enabled = true;
    }

    public void UseDodgeSkill()
    {
        dodge.fillAmount = 0;
        dodgeBright.enabled = false;
    }

    public void SetShootAmount(float amount)
    {
        shoot.fillAmount = amount;
    }

    public void SetShieldAmount(float amount)
    {
        shield.fillAmount = amount;
    }

    public void SetDodgeAmount(float amount)
    {
        dodge.fillAmount = amount;
    }
}
