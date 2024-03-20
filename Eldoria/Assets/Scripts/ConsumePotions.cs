using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsumePotions : MonoBehaviour
{
    public GameObject manaPotUI;
    public GameObject lifePotUI;
    public float manaColdown;
    public float lifeColdown;
    private bool canUseMana = true;
    private bool canUseLife = true;
    public int lifeIncrease;
    public int manaIncrease;
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
        int currMana = PlayerStats.GetMana();
        int currLife = PlayerStats.GetLife();
        int maxMana = PlayerStats.GetMaxMana();
        int maxLife = PlayerStats.GetMaxLife();

        // Life pot logic
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (canUseLife && currLife != maxLife)
            {
                if (currLife + lifeIncrease >= maxLife)
                {
                    PlayerStats.SetLife(maxLife);
                }
                else
                {
                    PlayerStats.AddLife(lifeIncrease);
                }

                drinkLife.Play();
                canUseLife = false;
                lifePotUI.GetComponent<Image>().fillAmount = 0;
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
                if (currMana + manaIncrease >= maxMana)
                {
                    PlayerStats.SetMana(maxMana);
                } else
                {
                    PlayerStats.AddMana(manaIncrease);
                }

                Debug.Log("Drinkkkkk");
                drinkMana.Play();
                canUseMana = false;
                manaPotUI.GetComponent<Image>().fillAmount = 0;
                Invoke("ManaColdown", manaColdown);
            } else
            {
                drinkError.Play();
            }

        }

        // This logic makes the potions image grow little by little
        if (!canUseMana)
        {
            manaPotUI.GetComponent<Image>().fillAmount += 1.0f / manaColdown * Time.deltaTime;
        }
        if (!canUseLife)
        {
            lifePotUI.GetComponent<Image>().fillAmount += 1.0f / lifeColdown * Time.deltaTime;
        }
    }

    private void ManaColdown()
    {
        canUseMana = true;
        manaPotUI.GetComponent<Image>().fillAmount = 1;
    }


    private void LifeColdown()
    {
        canUseLife = true;
        lifePotUI.GetComponent<Image>().fillAmount = 1;
    }

}
