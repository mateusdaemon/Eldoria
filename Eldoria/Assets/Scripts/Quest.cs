using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public string questTitle;
    public Goal[] goals;
    public HudManager hudManager;
    public bool enable = false;
    public bool active = false;
    private bool complete = false;
    private bool finish = false;

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
            complete = true;
        }
    }

    public void StartQuest()
    {
        hudManager.SetQuestText(goals[0].description);
    }

    
}
