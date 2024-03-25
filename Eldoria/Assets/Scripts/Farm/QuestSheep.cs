using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestSheep : MonoBehaviour
{
    public QuestManager qm;
    public GameObject questInteract;
    private bool canStartQuest = false;
    private int sheepInside = 0;
    private bool sheepContinue = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canStartQuest && Input.GetKeyUp(KeyCode.F))
        {
            if (!qm.GetSheepActive())
            {
                qm.ActiveSheepQuest();
                questInteract.SetActive(false);
            } else if (sheepContinue)
            {
                qm.SetSheepQuestDone(true);
                questInteract.SetActive(false);
            }
        }

        if (sheepInside == 5 && !qm.SheepQuestDone())
        {
            qm.SheepContinue();
            sheepContinue = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!qm.SheepQuestDone() && (!qm.GetSheepActive() || sheepContinue))
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
            questInteract.SetActive(false);
            canStartQuest = false;
        }
    }

    public void SumSheep()
    {
        sheepInside++;
        qm.UpdateSheepCount(sheepInside);
    }
}
