using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestCorn : MonoBehaviour
{
    public QuestManager qm;
    public GameObject questInteract;
    private bool canStartQuest = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canStartQuest && qm.SheepQuestDone() && !qm.GetCornActive() && Input.GetKeyDown(KeyCode.F))
        {
            qm.ActiveCornQuest();
            questInteract.SetActive(false);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!qm.GetCornActive() && qm.SheepQuestDone())
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
}
