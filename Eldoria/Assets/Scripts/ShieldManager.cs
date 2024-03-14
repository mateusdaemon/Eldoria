using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldManager : MonoBehaviour
{
    public GameObject redShield;
    public GameObject greenShield;
    public GameObject blueShield;
    public GameObject neutralShield;
    public SpellbookMng spellbook;
    GameObject currShield;
    public AudioSource shieldSfx;

    // Start is called before the first frame update
    void Start()
    {
        currShield = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            switch (spellbook.currSpellbook)
            {
                case SpellbookMng.Spellbook.Red:
                    currShield = Instantiate(redShield, this.transform.position, new Quaternion());
                    break;
                case SpellbookMng.Spellbook.Green:
                    currShield = Instantiate(greenShield, this.transform.position, new Quaternion());
                    break;
                case SpellbookMng.Spellbook.Blue:
                    currShield = Instantiate(blueShield, this.transform.position, new Quaternion());
                    break;
                case SpellbookMng.Spellbook.None:
                    currShield = Instantiate(neutralShield, this.transform.position, new Quaternion()); ;
                    break;
                default:
                    neutralShield = null;
                    break;
            }
            shieldSfx.Play();
            PlayerStats.SetShoot(false);
            PlayerStats.DropMana(2);
        }

        if (Input.GetMouseButtonUp(1))
        {
            if (currShield != null)
            {
                Destroy(currShield);
            }

            PlayerStats.SetShoot(true);
        }

        if (currShield != null)
        {
            Vector3 pos = transform.position;
            pos.y += 0.3f;
            currShield.transform.position = pos;
        }

    }
}
