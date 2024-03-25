using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestCorn : MonoBehaviour
{
    public QuestManager qm;
    public GameObject questInteract;
    public GameObject cornInteractor;
    private bool canStartQuest = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canStartQuest && qm.SheepQuestDone() && Input.GetKeyDown(KeyCode.F))
        {
            if (!qm.GetCornActive())
            {
                qm.ActiveCornQuest();
                cornInteractor.SetActive(true);
            } else if (qm.GetFinishCorn())
            {
                qm.CornFinish();
            }
            questInteract.SetActive(false);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (qm.CornQuestDone())
            {
                return;
            }
            if ((!qm.GetCornActive() && qm.SheepQuestDone()) || qm.GetFinishCorn())
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
            if (qm.CornQuestDone())
            {
                return;
            }
            questInteract.SetActive(false);
            canStartQuest = false;
        }
    }
}
