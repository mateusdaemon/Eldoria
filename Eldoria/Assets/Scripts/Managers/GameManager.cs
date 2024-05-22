using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public SoundManager sm;
    public HudManager hudManager;
    public GameObject playerRef;
    public int maxFPS;

    private float shootManaCost = 1;
    private float shieldManaCost = 2;
    private float maxShieldPoints = 7;

    private Quest startSceneQuest;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = maxFPS;

        if (SceneManager.GetActiveScene().name == "Farm")
        {
            PlayerStats.EnableSkill(false);
        } else if (SceneManager.GetActiveScene().name == "FarmNight")
        {
            startSceneQuest = FindObjectOfType<QuestList>().quests[0];
            startSceneQuest.StartQuest();
            PlayerStats.EnableSkill(true);
        }
    }

    public void SetShootCost(float cost)
    {
        shootManaCost = cost;
    }

    public void PlayerShoot()
    {
        PlayerStats.DropMana(shootManaCost);
        hudManager.UseShootSkill();
        hudManager.SetManaAmount(PlayerStats.GetMana()/PlayerStats.GetMaxMana());
    }

    public void EnableShoot()
    {
        hudManager.ActivateShootSkill();
    }

    public void PlayerUseShield()
    {
        PlayerStats.DropMana(shieldManaCost);
        PlayerStats.SetShieldPoints(maxShieldPoints);
        hudManager.UseShieldSkill();
        hudManager.SetManaAmount(PlayerStats.GetMana() / PlayerStats.GetMaxMana());
    }
    public void EnableShield()
    {
        hudManager.ActivateShieldSkill();
    }

    public float GetShieldCost()
    {
        return shieldManaCost;
    }

    public void PlayerDodge()
    {
        hudManager.UseDodgeSkill();
    }

    public void EnableDodge()
    {
        hudManager.ActivateDodgeSkill();
    }

    public void DrinkLifePot(float life)
    {
        hudManager.UseLifePot();
        PlayerStats.AddLife(life);
        hudManager.SetLifeAmout(PlayerStats.GetLife() / PlayerStats.GetMaxLife());

        if (life >= 5 && hudManager.damageFeedback.activeSelf)
        {
            hudManager.DisableHurtFeedback();
        }
    }

    public void DrinkManaPot(float mana)
    {
        hudManager.UseManaPot();
        PlayerStats.AddMana(mana);
        hudManager.SetManaAmount(PlayerStats.GetMana() / PlayerStats.GetMaxMana());
    }

    public void EnableLifePot()
    {
        hudManager.ActivateLifePot();
    }

    public void EnableManaPot()
    {
        hudManager.ActivateManaPot();
    }

    public void AttackPlayer(float damage)
    {
        float damageToLife = 0;

        if (PlayerStats.GetShieldPoints() > 0)
        {
            if (PlayerStats.GetShieldPoints() > damage)
            {
                PlayerStats.SetShieldPoints(PlayerStats.GetShieldPoints() - damage);
                hudManager.SetShieldBarAmount(PlayerStats.GetShieldPoints() / maxShieldPoints);
            } else
            {
                PlayerStats.SetShieldPoints(0);
                hudManager.BreakShield();
                damageToLife = damage - PlayerStats.GetShieldPoints();
                playerRef.GetComponentInChildren<ShieldManager>().DestroyShield();
                sm.PlaySfx(sm.sfxShieldDestroy);
            }
        } else { damageToLife = damage; }

        if (damageToLife > 0)
        {
            playerRef.GetComponent<PlayerDamageFdb>().DamageFeedback();
            sm.PlaySfx(sm.sfxTakingDamage);
        } else
        {
            sm.PlaySfx(sm.sfxTakingShieldDamage);
        }

        float playerLife = PlayerStats.GetLife();

        PlayerStats.DropLife(damageToLife);
        hudManager.SetLifeAmout(playerLife / PlayerStats.GetMaxLife());

        if (playerLife < 5)
        {
            hudManager.EnableHurtFeedback();
            if (playerLife < 3)
            {
                hudManager.DyingFeedback();
            }
            else
            {
                hudManager.HurtFeedback();
            }
        }
    }

    public void CantShootFeedback()
    {
        hudManager.SetShootInvalid();
    }

    public void RestoreShootFeedback()
    {
        hudManager.RestorShootColor();
    }

    public void CantShieldFeedback()
    {
        hudManager.SetShieldInvalid();
    }

    public void RestoreShieldFeedback()
    {
        hudManager.RestorShieldColor();
    }

    public void CantDodgeFeedback()
    {
        hudManager.SetDodgeInvalid();
    }

    public void RestoreDodgeFeedback()
    {
        hudManager.RestorDodgeColor();
    }

    public void LoadScene(string scenemName)
    {
        SceneManager.LoadScene(scenemName);
    }
}
