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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
        canUseMana = true;
        gm.EnableManaPot();
    }

    private void LifeColdown()
    {
        canUseLife = true;
        gm.EnableLifePot();
    }

}
