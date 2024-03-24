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
}
