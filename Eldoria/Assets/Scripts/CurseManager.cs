using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurseManager : MonoBehaviour
{
    public SpellbookMng spellbook;
    public GameObject redCurseUI;
    public GameObject greenCurseUI;
    public GameObject blueCurseUI;
    public AudioSource breakCurseSfx;

    private bool beingRedCursed = false;
    private bool beingGreenCursed = false;
    private bool beingBlueCursed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        redCurseUI.SetActive(PlayerStats.RedCursed());
        greenCurseUI.SetActive(PlayerStats.GreenCursed());
        blueCurseUI.SetActive(PlayerStats.BlueCursed());

        if (PlayerStats.RedCursed() && !beingRedCursed)
        {
            beingRedCursed = true;
            Invoke("DamageByRedCurse", 0);
        }

        if (PlayerStats.GreenCursed() && !beingGreenCursed)
        {
            beingGreenCursed = true;
            Invoke("DamageByGreenCurse", 0);
        }

        if (PlayerStats.BlueCursed() && !beingBlueCursed)
        {
            beingBlueCursed = true;
            Invoke("DamageByBlueCurse", 0);
        }

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
            breakCurseSfx.Play();
            PlayerStats.DropMana(2);
        }
    }

    private void DamageByRedCurse()
    {
        if (PlayerStats.RedCursed())
        {
            PlayerStats.DropLife(1);
            Invoke("DamageByRedCurse", 2);
        } else
        {
            beingRedCursed = false;
        }
    }
    private void DamageByGreenCurse()
    {
        if (PlayerStats.GreenCursed())
        {
            PlayerStats.DropLife(1);
            Invoke("DamageByGreenCurse", 2);
        } else
        {
            beingGreenCursed = false;
        }
    }
    private void DamageByBlueCurse()
    {
        if (PlayerStats.BlueCursed())
        {
            PlayerStats.DropLife(1);
            Invoke("DamageByBlueCurse", 2);
        } else
        {
            beingBlueCursed = false;
        }
    }
}
