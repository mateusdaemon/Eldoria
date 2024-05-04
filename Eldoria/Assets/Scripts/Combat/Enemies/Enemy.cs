using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [Header("Attributes")]
    public float life;
    public float damage;
    public SpellbookMng.Spellbook curse;

    [Header("UI")]
    public Image lifeBar;

    private float currentLife = 0;
    private GameManager gm;


    // Start is called before the first frame update
    void Start()
    {
        currentLife = life;
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentLife <= 0)
        {
            Destroy(this.gameObject);
        }
        
    }

    public void AttackPlayer()
    {
        gm.AttackPlayer(damage);
    }

    public void TakeDamage(float damage)
    {
        currentLife-=damage;
        lifeBar.fillAmount = currentLife/life;
    }

    public void ResetLife()
    {
        currentLife = life;
        lifeBar.fillAmount = 1.0f;
    }
}
