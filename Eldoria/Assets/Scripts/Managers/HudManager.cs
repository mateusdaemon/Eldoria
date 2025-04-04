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
    public Image shieldBar;
    public GameObject manaBarObject;

    [Header("Potions")]
    public Image lifePot;
    public Image lifePotShine;
    public Image manaPot;
    public Image manaPotShine;
    public Image lifePotColdown;
    public Image manaPotColdown;
    public GameObject potionsObject;

    [Header("Quests")]
    public TextMeshProUGUI questTitle;
    public TextMeshProUGUI questText;
    public GameObject completeQuest;

    [Header("Books")]
    public GameObject books;
    public Image neutralSelect;

    [Header("Skills")]
    public Image shootBG;
    public Image shoot;
    public Image shootBright;
    public Image shieldBG;
    public Image shield;
    public Image shieldBright;
    public Image dodgeBG;
    public Image dodge;
    public Image dodgeBright;
    public GameObject skillsObject;

    [Header("Keys")]
    public GameObject keysObject;

    [Header("Screen Feedbacks")]
    public GameObject damageFeedback;

    [Header("Pause Menu")]
    public GameObject pauseMenu;

    [Header("Arena")]
    public GameObject roundComplete;
    public GameObject nextRound;

    public void SetLifeAmout(float amount)
    {
        lifeBar.fillAmount = amount;
    }

    public void SetManaAmount(float amount)
    {
        manaBar.fillAmount = amount;
    }

    public void SetShieldBarAmount(float amount)
    {
        shieldBar.fillAmount = amount;
    }

    public void SetQuestTitle(string text)
    {
        questTitle.text = text;
    }
    public void SetQuestText(string text)
    {
        questText.text = text;
    }

    public void SetTextNoQuest()
    {
        questText.text = "Nada de novo por aqui";
    }

    #region POTIONS
    public void ActivateLifePot()
    {
        lifePot.fillAmount = 1;
        lifePotColdown.enabled = false;
        lifePotShine.enabled = true;
    }

    public void ActivateManaPot()
    {
        manaPot.fillAmount = 1;
        manaPotColdown.enabled = false;
        manaPotShine.enabled = true;
    }

    public void UseLifePot()
    {
        lifePot.fillAmount = 0;
        lifePotColdown.enabled = true;
        lifePotColdown.fillAmount = 1;
        lifePotShine.enabled = false;
    }

    public void SetLifePotAmount(float amount)
    {
        lifePot.fillAmount = amount;
    }

    public void SetLifeColdownAmount(float amount)
    {
        lifePotColdown.fillAmount = amount;
    }

    public void UseManaPot()
    {
        manaPot.fillAmount = 0;
        manaPotColdown.enabled = true;
        manaPotColdown.fillAmount = 1;
        manaPotShine.enabled = false;
    }

    public void SetManaPotAmount(float amount)
    {
        manaPot.fillAmount = amount;
    }

    public void SetManaColdownAmount(float amount)
    {
        manaPotColdown.fillAmount = amount;
    }
    #endregion

    #region SKILLS
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
        shieldBar.enabled = true;
        shieldBar.fillAmount = 1;
    }

    public void BreakShield()
    {
        shieldBar.enabled = false;
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

    public void SetShootInvalid()
    {
        shoot.color = Color.red;
        shootBG.color = Color.red;
    }

    public void RestorShootColor()
    {
        shoot.color = Color.white;
        shootBG.color = Color.white;
    }

    public void SetShieldInvalid()
    {
        shield.color = Color.red;
        shieldBG.color = Color.red;
    }

    public void RestorShieldColor()
    {
        shield.color = Color.white;
        shieldBG.color = Color.white;
    }

    public void SetDodgeInvalid()
    {
        dodge.color = Color.red;
        dodgeBG.color = Color.red;
    }

    public void RestorDodgeColor()
    {
        dodge.color = Color.white;
        dodgeBG.color = Color.white;
    }
    #endregion

    public void ActivateNeutralBook()
    {
        neutralSelect.enabled = true;
    }

    public void ActivateCombatObjects()
    {
        manaBarObject.SetActive(true);
        potionsObject.SetActive(true);
        skillsObject.SetActive(true);
        keysObject.SetActive(true);
        books.SetActive(true);
    }

    public void EnableHurtFeedback()
    {
        if (!damageFeedback.activeSelf)
        {
            damageFeedback.SetActive(true);
            damageFeedback.GetComponent<Animator>().SetBool("hurt", true);
            damageFeedback.GetComponent<Animator>().SetBool("dying", false);
        }
    }

    public void DisableHurtFeedback()
    {
        if (damageFeedback.activeSelf)
        {
            damageFeedback.GetComponent<Animator>().SetBool("hurt", false);
            damageFeedback.GetComponent<Animator>().SetBool("dying", false);
            damageFeedback.SetActive(false);
        }
    }

    public void DyingFeedback()
    {
        damageFeedback.GetComponent<Animator>().SetBool("hurt", false);
        damageFeedback.GetComponent<Animator>().SetBool("dying", true);
    }

    public void HurtFeedback()
    {
        damageFeedback.GetComponent<Animator>().SetBool("hurt", true);
        damageFeedback.GetComponent<Animator>().SetBool("dying", false);
    }

    public void PauseGame(bool pause)
    {
        if (pause)
        {
            pauseMenu.SetActive(true);
        } else
        {
            pauseMenu.SetActive(false);
        }
    }

    public void RoundComplete()
    {
        roundComplete.SetActive(true);
        Invoke("DisableRoundComplete", 2);
        Invoke("EnableNextRound", 2.5f);
    }

    public void EnableNextRound()
    {
        nextRound.SetActive(true);
        Invoke("DisableNextRound", 2);
    }

    public void DisableRoundComplete()
    {
        roundComplete.SetActive(false);
    }

    public void DisableNextRound()
    {
        nextRound.SetActive(false);
    }

    public void EnableCompleteQuest()
    {
        completeQuest.SetActive(true);
        Invoke("DisableCompleteQuest", 2.5f);
    }

    public void DisableCompleteQuest()
    {
        completeQuest.SetActive(false);
    }
}
