using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public HudManager hudManager;

    private bool onQuest = false;

    public bool QuestInProgress()
    {
        return onQuest;
    }

    public void SetQuestInProgress(bool inProgress)
    {
        onQuest = inProgress;
    }
}
