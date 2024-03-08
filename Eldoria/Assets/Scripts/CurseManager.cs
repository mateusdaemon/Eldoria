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
                    PlayerStats.CurseRed(true);
                    redCurseUI.SetActive(true);
                    break;
                case SpellbookMng.Spellbook.Green:
                    PlayerStats.CurseGreen(true);
                    greenCurseUI.SetActive(true);
                    break;
                case SpellbookMng.Spellbook.Blue:
                    PlayerStats.CurseBlue(true);
                    blueCurseUI.SetActive(true);
                    break;
                default:
                    break;
            }
            PlayerStats.DropLife(currEnemy.damage);
        }
    }
}
