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
        if (canUseLife && Input.GetKeyDown(KeyCode.E) && currLife != maxLife)
        {
            if (currLife + lifeIncrease >= maxLife)
            {
                PlayerStats.SetLife(maxLife);
            }
            else
            {
                PlayerStats.AddLife(lifeIncrease);
            }

            canUseLife = false;
            lifePotUI.GetComponent<Image>().fillAmount = 0;
            Invoke("LifeColdown", lifeColdown);
        }

        // Mana pot logic
        if (canUseMana && Input.GetKeyDown(KeyCode.R) && currMana != maxMana)
        {
            if (currMana + manaIncrease >= maxMana)
            {
                PlayerStats.SetMana(maxMana);
            } else
            {
                PlayerStats.AddMana(manaIncrease);
            }

            canUseMana = false;
            manaPotUI.GetComponent<Image>().fillAmount = 0;
            Invoke("ManaColdown", manaColdown);
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
