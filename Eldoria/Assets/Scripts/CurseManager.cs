using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurseManager : MonoBehaviour
{
    public SpellbookMng spellbook;
    public GameObject redCurseUI;
    public GameObject greenCurseUI;
    public GameObject blueCurseUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            switch (spellbook.currSpellbook)
            {
                case SpellbookMng.Spellbook.Red:
                    PlayerStats.CurseRed(false);
                    redCurseUI.SetActive(false);
                    break;
                case SpellbookMng.Spellbook.Green:
                    PlayerStats.CurseGreen(false);
                    greenCurseUI.SetActive(false);
                    break;
                case SpellbookMng.Spellbook.Blue:
                    PlayerStats.CurseBlue(false);
                    blueCurseUI.SetActive(false);
                    break;
                default:
                    break;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Enemy currEnemy = collision.gameObject.GetComponent<Enemy>();
            switch (currEnemy.curse)
            {
                case SpellbookMng.Spellbook.Red:
                    if (PlayerStats.RedCursed())
                        break;

                    PlayerStats.CurseRed(true);
                    redCurseUI.SetActive(true);
                    Invoke("DamageByRedCurse", 0);
                    break;

                case SpellbookMng.Spellbook.Green:
                    if (PlayerStats.GreenCursed())
                        break;

                    PlayerStats.CurseGreen(true);
                    greenCurseUI.SetActive(true);
                    Invoke("DamageByGreenCurse", 0);
                    break;

                case SpellbookMng.Spellbook.Blue:
                    if (PlayerStats.BlueCursed())
                        break;

                    PlayerStats.CurseBlue(true);
                    blueCurseUI.SetActive(true);
                    Invoke("DamageByBlueCurse", 0);
                    break;

                default:
                    break;
            }

            PlayerStats.DropLife(currEnemy.damage);
        }
    }

    private void DamageByRedCurse()
    {
        if (PlayerStats.RedCursed())
        {
            PlayerStats.DropLife(1);
            Invoke("DamageByRedCurse", 2);
        }
    }
    private void DamageByGreenCurse()
    {
        if (PlayerStats.GreenCursed())
        {
            PlayerStats.DropLife(1);
            Invoke("DamageByGreenCurse", 2);
        }
    }
    private void DamageByBlueCurse()
    {
        if (PlayerStats.BlueCursed())
        {
            PlayerStats.DropLife(1);
            Invoke("DamageByBlueCurse", 2);
        }
    }
}
