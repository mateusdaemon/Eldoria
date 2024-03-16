using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public bool hitPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hitPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hitPlayer = false;
        }
    }

    public void AttackPlayer(Enemy currEnemy)
    {
        bool hit = true;
        switch (currEnemy.curse)
        {
            case SpellbookMng.Spellbook.None:
                if (PlayerStats.IsNeutralShielded())
                {
                    hit = false;
                }
                break;
            case SpellbookMng.Spellbook.Red:
                if (PlayerStats.IsRedShielded())
                {
                    hit = false;
                } else
                {
                    PlayerStats.CurseRed(true);
                }
                break;
            case SpellbookMng.Spellbook.Green:
                if (PlayerStats.IsGreenShielded())
                {
                    hit = false;
                }
                else
                {
                    PlayerStats.CurseGreen(true);
                }
                break;
            case SpellbookMng.Spellbook.Blue:
                if (PlayerStats.IsBlueShielded())
                {
                    hit = false;
                }
                else
                {
                    PlayerStats.CurseBlue(true);
                }
                break;
            default:
                break;
        }

        if (hit)
        {
            PlayerStats.DropLife(currEnemy.damage);
        }
    }
}
