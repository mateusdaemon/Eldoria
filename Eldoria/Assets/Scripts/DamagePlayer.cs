using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Enemy currEnemy = GetComponent<Enemy>();
            switch (currEnemy.curse)
            {
                case SpellbookMng.Spellbook.Red:
                    if (PlayerStats.RedCursed())
                        break;

                    PlayerStats.CurseRed(true);
                    break;

                case SpellbookMng.Spellbook.Green:
                    if (PlayerStats.GreenCursed())
                        break;

                    PlayerStats.CurseGreen(true);
                    break;

                case SpellbookMng.Spellbook.Blue:
                    if (PlayerStats.BlueCursed())
                        break;

                    PlayerStats.CurseBlue(true);
                    break;

                default:
                    break;
            }

            PlayerStats.DropLife(currEnemy.damage);
        }
    }
}
