using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestCorn : MonoBehaviour
{
    public GameManager gm;
    public GameObject questInteract;
    private bool canStartQuest = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canStartQuest && gm.SheepQuestDone() && !gm.GetCornActive() && Input.GetKeyDown(KeyCode.F))
        {
            gm.ActiveCornQuest();
            questInteract.SetActive(false);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!gm.GetCornActive() && gm.SheepQuestDone())
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
            if (!gm.GetCornActive())
            {
                questInteract.SetActive(false);
                canStartQuest = false;
            }
        }
    }
}
