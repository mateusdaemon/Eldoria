using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestList : MonoBehaviour
{
    public QuestManager qm;
    public Quest[] quests;
    public GameObject questInteract;
    private bool canInteract = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.F))
        {
            foreach (Quest quest in quests)
            {
                if (quest.enable && !quest.active)
                {
                    quest.StartQuest();
                    quest.active = true;
                    qm.SetQuestInProgress(true);
                    canInteract = false;
                    questInteract.SetActive(false);
                }
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!qm.QuestInProgress())
            {
                canInteract = true;
                questInteract.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = false;
            questInteract.SetActive(false);
        }
    }
}
