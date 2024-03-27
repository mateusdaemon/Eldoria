using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsumePotions : MonoBehaviour
{
    public GameManager gm;
    public float manaColdown;
    public float lifeColdown;
    private bool canUseMana = true;
    private bool canUseLife = true;
    public float lifeIncrease;
    public float manaIncrease;
    public AudioSource drinkLife;
    public AudioSource drinkMana;
    public AudioSource drinkError;

    private float manaAmount = 0;
    private float manaColdownAmount = 1;
    private float lifeAmount = 0;
    private float lifeColdownAmount = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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

                gm.DrinkLifePot(lifeToAdd);
                drinkLife.Play();
                canUseLife = false;
                Invoke("LifeColdown", lifeColdown);
            } else
            {
                drinkError.Play();
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

                gm.DrinkManaPot(manaToAdd);
                drinkMana.Play();
                canUseMana = false;
                Invoke("ManaColdown", manaColdown);
            } else
            {
                drinkError.Play();
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
