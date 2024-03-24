using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestSheep : MonoBehaviour
{
    public GameManager gm;
    public GameObject questInteract;
    private bool canStartQuest = false;
    private int sheepInside = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canStartQuest && !gm.GetSheepActive() && Input.GetKeyUp(KeyCode.F))
        {
            gm.ActiveSheepQuest();
            questInteract.SetActive(false);
        }

        if (sheepInside == 5)
        {
            gm.SetSheepQuestDone(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!gm.GetSheepActive())
            {
                questInteract.SetActive(true);
                canStartQuest = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!gm.GetSheepActive())
            {
                questInteract.SetActive(false);
                canStartQuest = false;
            }
        }
    }

    public void SumSheep()
    {
        sheepInside++;
    }
}
