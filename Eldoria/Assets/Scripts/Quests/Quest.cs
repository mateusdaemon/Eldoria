using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    [Header("Managers")]
    public QuestManager qm;
    public HudManager hudManager;

    [Header("Quest info")]
    public string questTitle;
    public Goal[] goals;
    public bool enable = false;
    public bool active = false;
    public Dialogue questDialogue;

    [Header("Next quest")]
    public Quest nextQuest;

    private bool complete = false;
    //private bool finish = false;
    private string noQuestTitle = "...";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckForComplete()
    {
        bool questDone = true;
        foreach (Goal goal in goals)
        {
            if (!goal.Complete())
            {
                questDone = false;
                hudManager.SetQuestText(goal.description);
                return;
            }
        }

        if (questDone)
        {
            hudManager.SetTextNoQuest();
            hudManager.SetQuestTitle(noQuestTitle);
            qm.SetQuestInProgress(false);
            complete = true;
            nextQuest.enable = true;
        }
    }

    public void StartQuest()
    {
        hudManager.SetQuestTitle(questTitle);
        hudManager.SetQuestText(goals[0].description);
    }

    
}
