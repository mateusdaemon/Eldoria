using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldManager : MonoBehaviour
{
    [Header("---Manager---")]
    public GameManager gm;
    public SoundManager sm;

    [Header("---Shield---")]
    public GameObject redShield;
    public GameObject greenShield;
    public GameObject blueShield;
    public GameObject neutralShield;
    public SpellbookMng spellbook;
    public GameObject player;

    private GameObject currShield;
    private SpellbookMng.Spellbook shieldCurse;


    // Start is called before the first frame update
    void Start()
    {
        currShield = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerStats.GetMana() >= gm.GetShieldCost() && Input.GetMouseButtonDown(1))
        {
            switch (spellbook.currSpellbook)
            {
                case SpellbookMng.Spellbook.Red:
                    currShield = Instantiate(redShield, this.transform.position, new Quaternion());
                    shieldCurse = SpellbookMng.Spellbook.Red;
                    PlayerStats.SetRedShielded(true);
                    break;
                case SpellbookMng.Spellbook.Green:
                    currShield = Instantiate(greenShield, this.transform.position, new Quaternion());
                    shieldCurse = SpellbookMng.Spellbook.Green;
                    PlayerStats.SetGreenShielded(true);
                    break;
                case SpellbookMng.Spellbook.Blue:
                    currShield = Instantiate(blueShield, this.transform.position, new Quaternion());
                    shieldCurse = SpellbookMng.Spellbook.Blue;
                    PlayerStats.SetBlueShielded(true);
                    break;
                case SpellbookMng.Spellbook.None:
                    currShield = Instantiate(neutralShield, this.transform.position, new Quaternion());
                    shieldCurse = SpellbookMng.Spellbook.None;
                    PlayerStats.SetNeutralShielded(true);
                    break;
                default:
                    neutralShield = null;
                    break;
            }

            // Shield height correction
            currShield.transform.position = new Vector3(currShield.transform.position.x, currShield.transform.position.y + 0.2f, currShield.transform.position.z);

            sm.PlaySfx(sm.sfxShield);
            gm.PlayerUseShield();
            player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0); // Disable movement
        }

        if (Input.GetMouseButtonUp(1))
        {
            if (currShield != null)
            {
                Destroy(currShield);
                switch (shieldCurse)
                {
                    case SpellbookMng.Spellbook.None:
                        PlayerStats.SetNeutralShielded(false);
                        break;
                    case SpellbookMng.Spellbook.Red:
                        PlayerStats.SetRedShielded(false);
                        break;
                    case SpellbookMng.Spellbook.Green:
                        PlayerStats.SetGreenShielded(false);
                        break;
                    case SpellbookMng.Spellbook.Blue:
                        PlayerStats.SetBlueShielded(false);
                        break;
                    default:
                        break;
                }
            }

            gm.EnableShield();
        }
    }
}
