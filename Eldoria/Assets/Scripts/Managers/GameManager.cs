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
    public int maxFPS;

    private float shootManaCost = 1;
    private float shieldManaCost = 2;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = maxFPS;

        if (SceneManager.GetActiveScene().name == "Farm")
        {
            PlayerStats.EnableSkill(false);
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
        PlayerStats.SetShoot(false);
        PlayerStats.SetMove(false);
        PlayerStats.DropMana(shieldManaCost);
        hudManager.UseShieldSkill();
        hudManager.SetManaAmount(PlayerStats.GetMana() / PlayerStats.GetMaxMana());
    }
    public void EnableShield()
    {
        PlayerStats.SetShoot(true);
        PlayerStats.SetMove(true);
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
        sm.PlaySfx(sm.sfxTakingDamage);
        PlayerStats.DropLife(damage);
        hudManager.SetLifeAmout(PlayerStats.GetLife() / PlayerStats.GetMaxLife());
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
}
