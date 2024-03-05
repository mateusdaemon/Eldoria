using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellbookMng : MonoBehaviour
{
    public enum Spellbook {None, Red, Green, Blue};
    public Spellbook currSpellbook;

    // Start is called before the first frame update
    void Start()
    {
        currSpellbook = Spellbook.None;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currSpellbook = Spellbook.Red;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currSpellbook = Spellbook.Green;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currSpellbook = Spellbook.Blue;
        } else if (Input.GetKeyDown(KeyCode.Space))
        {
            currSpellbook = Spellbook.None;
        }
    }
}
