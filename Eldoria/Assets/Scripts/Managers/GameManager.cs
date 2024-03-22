using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI manaLabel;
    public TextMeshProUGUI lifeLabel;
    public GameObject manaBar;
    public GameObject lifeBar;
    public int maxFPS;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = maxFPS;
    }

    // Update is called once per frame
    void Update()
    {
        manaLabel.text = PlayerStats.GetMana() + "/" + PlayerStats.GetMaxMana();

        float maxMana = (float) PlayerStats.GetMaxMana(); 
        float currMana = (float)PlayerStats.GetMana();
        float percOfMana = currMana / maxMana;

        manaBar.GetComponent<Image>().fillAmount = percOfMana;

        lifeLabel.text = PlayerStats.GetLife() + "/" + PlayerStats.GetMaxLife();

        float maxLife = (float)PlayerStats.GetMaxLife();
        float currLife = (float)PlayerStats.GetLife();
        float percOfLife = currLife / maxLife;

        lifeBar.GetComponent<Image>().fillAmount = percOfLife;
    }
}
