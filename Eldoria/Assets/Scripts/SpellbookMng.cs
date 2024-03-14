using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellbookMng : MonoBehaviour
{
    public enum Spellbook {None, Red, Green, Blue};
    public Spellbook currSpellbook;
    public GameObject redActive;
    public GameObject greenActive;
    public GameObject blueActive;

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
            currSpellbook = Spellbook.None;
            greenActive.SetActive(false);
            redActive.SetActive(false);
            blueActive.SetActive(false);
        } else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currSpellbook = Spellbook.Green;
            greenActive.SetActive(true);
            redActive.SetActive(false);
            blueActive.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currSpellbook = Spellbook.Red;
            redActive.SetActive(true);
            greenActive.SetActive(false);
            blueActive.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            currSpellbook = Spellbook.Blue;
            blueActive.SetActive(true);
            redActive.SetActive(false);
            greenActive.SetActive(false);
        }
    }
}
