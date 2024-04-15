using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameManager gm;
    public int life;
    public int damage;
    public SpellbookMng.Spellbook curse;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0)
        {
            Destroy(this.gameObject);
        }
        
    }

    public void AttackPlayer()
    {
        gm.AttackPlayer(damage);
    }

    public void TakeDamage()
    {

    }
}
