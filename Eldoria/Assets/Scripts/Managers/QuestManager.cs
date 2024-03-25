using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public HudManager hudManager;

    // SHEEP QUEST
    private bool sheepActive = false;
    private bool sheepQuestDone = false;
    private string sheepQuestText1 = "-> Procure as ovelhas e leve-as para dentro da fazenda.";
    private string sheepQuestText2 = "-> Volte a falar com seu irmão.";
    private string sheepQuestText3 = "(sem missões)";

    //CORN QUEST
    private bool cornActive = false;
    private bool cornQuestDone = false;
    private bool wagonInteract = false;
    private bool finishCornQuest = false;
    private string cornQuestText1 = "-> Colha todos os milhos na plantação.";
    private string cornQuestText2 = "-> Coloque os milhos na carroça.";
    private string cornQuestText3 = "-> Volte a falar com seu pai.";
    private string cornQuestText4 = "(sem missões)";

    #region SHEEP_QUEST
    public void ActiveSheepQuest()
    {
        string text = sheepQuestText1 + "(0/5)";
        sheepActive = true;
        hudManager.SetQuestText(text);
    }

    public bool GetSheepActive()
    {
        return sheepActive;
    }

    public void SheepContinue()
    {
        hudManager.SetQuestText(sheepQuestText2);
    }

    public void SetSheepQuestDone(bool done)
    {
        sheepQuestDone = done;
        hudManager.SetQuestText(sheepQuestText3);
    }

    public bool SheepQuestDone()
    {
        return sheepQuestDone;
    }

    public void UpdateSheepCount(int count)
    {
        string text = sheepQuestText1 + "(" + count + "/5) ";
        hudManager.SetQuestText(text);
    }
    #endregion

    #region CORN_QUEST
    public void ActiveCornQuest()
    {
        cornActive = true;
        hudManager.SetQuestText(cornQuestText1);
    }

    public bool GetCornActive()
    {
        return cornActive;
    }

    public bool CornQuestDone()
    {
        return cornQuestDone;
    }

    public void SetCornQuestDone(bool done)
    {
        cornQuestDone = done;
    }

    public void CornContinue()
    {
        hudManager.SetQuestText(cornQuestText2);
    }

    public void CornLastContinue()
    {
        hudManager.SetQuestText(cornQuestText3);
    }

    public void CornFinish()
    {
        hudManager.SetQuestText(cornQuestText4);
    }

    public void SetWagonInteract(bool interact)
    {
        wagonInteract = interact;
    }

    public bool GetWagonInteract()
    {
        return wagonInteract;
    }

    public void SetFinishCorn(bool finish)
    {
        finishCornQuest = finish;
    }

    public bool GetFinishCorn()
    {
        return finishCornQuest;
    }
    #endregion
}
