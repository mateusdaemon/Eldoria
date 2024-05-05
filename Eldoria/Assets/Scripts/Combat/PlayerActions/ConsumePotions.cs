using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsumePotions : MonoBehaviour
{
    [Header("---Manager---")]
    private GameManager gm;

    [Header("---Potion---")]
    public float manaColdown;
    public float lifeColdown;
    private bool canUseMana = true;
    private bool canUseLife = true;
    public float lifeIncrease;
    public float manaIncrease;

    [Header("---Feedbacks---")]
    public ParticleSystem lifePotFdb;
    public ParticleSystem manaPotFdb;


    private float manaAmount = 0;
    private float manaColdownAmount = 1;
    private float lifeAmount = 0;
    private float lifeColdownAmount = 1;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerStats.SkillEnable() || PlayerStats.IsDialoguing())
        {
            return;
        }

        if (!canUseMana)
        {
            manaAmount += 1.0f / manaColdown * Time.deltaTime;
            manaColdownAmount -= 1.0f / manaColdown * Time.deltaTime;
            gm.hudManager.SetManaPotAmount(manaAmount);
            gm.hudManager.SetManaColdownAmount(manaColdownAmount);
        }

        if (!canUseLife)
        {
            lifeAmount += 1.0f / lifeColdown * Time.deltaTime;
            lifeColdownAmount -= 1.0f / lifeColdown * Time.deltaTime;
            gm.hudManager.SetLifePotAmount(lifeAmount);
            gm.hudManager.SetLifeColdownAmount(lifeColdownAmount);
        }

        float currMana = PlayerStats.GetMana();
        float currLife = PlayerStats.GetLife();
        float maxMana = PlayerStats.GetMaxMana();
        float maxLife = PlayerStats.GetMaxLife();

        // Life pot logic
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (canUseLife && currLife != maxLife)
            {
                float lifeToAdd = lifeIncrease;
                if (currLife + lifeIncrease >= maxLife)
                {
                    lifeToAdd = maxLife - currLife;
                }

                lifePotFdb.Play();

                gm.DrinkLifePot(lifeToAdd);
                gm.sm.PlaySfx(gm.sm.sfxDrinkLife);
                canUseLife = false;
                Invoke("LifeColdown", lifeColdown);
            } else
            {
                gm.sm.PlaySfx(gm.sm.sfxErroManaHeal);
            }
        }

        // Mana pot logic
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (canUseMana && currMana != maxMana)
            {
                float manaToAdd = manaIncrease;
                if (currMana + manaIncrease >= maxMana)
                {
                    manaToAdd = maxMana - currMana;
                }

                manaPotFdb.Play();

                gm.DrinkManaPot(manaToAdd);
                gm.sm.PlaySfx(gm.sm.sfxDrinkMana);
                canUseMana = false;
                Invoke("ManaColdown", manaColdown);
            } else
            {
                gm.sm.PlaySfx(gm.sm.sfxErroManaHeal);
            }
        }
    }

    private void ManaColdown()
    {
        manaAmount = 0;
        manaColdownAmount = 1;
        canUseMana = true;
        gm.EnableManaPot();
    }

    private void LifeColdown()
    {
        lifeAmount = 0;
        lifeColdownAmount = 1;
        canUseLife = true;
        gm.EnableLifePot();
    }

}
