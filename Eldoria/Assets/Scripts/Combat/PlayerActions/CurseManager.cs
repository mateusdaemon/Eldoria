using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurseManager : MonoBehaviour
{
    [Header("---Manager---")]
    public SoundManager sm;

    [Header("---Curse---")]
    public SpellbookMng spellbook;
    public int manaCost;
    public GameObject redCurseUI;
    public GameObject greenCurseUI;
    public GameObject blueCurseUI;

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
            bool mistake = false;

            if (manaCost <= PlayerStats.GetMana())
            {
                switch (spellbook.currSpellbook)
                {
                    case SpellbookMng.Spellbook.Red:
                        if (!PlayerStats.RedCursed())
                        {
                            mistake = true;
                        } else
                        {
                            PlayerStats.CurseRed(false);
                            redCurseUI.SetActive(false);
                        }
                        break;
                    case SpellbookMng.Spellbook.Green:
                        if (!PlayerStats.GreenCursed())
                        {
                            mistake = true;
                        } else
                        {
                            PlayerStats.CurseGreen(false);
                            greenCurseUI.SetActive(false);
                        }
                        break;
                    case SpellbookMng.Spellbook.Blue:
                        if (!PlayerStats.BlueCursed())
                        {
                            mistake = true;
                        } else
                        {
                            PlayerStats.CurseBlue(false);
                            blueCurseUI.SetActive(false);
                        }
                        break;
                    default:
                        mistake = true;
                        break;
                }

                PlayerStats.DropMana(manaCost);
            } else
            {
                mistake = true;
            }

            if (mistake)
            {
                sm.PlaySfx(sm.sfxErroBreakCurse);
            } else
            {
                sm.PlaySfx(sm.sfxBreakCurse);
            }
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
