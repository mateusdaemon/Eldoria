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
    private string sheepQuestText2 = "-> Volte a falar com seu irm�o.";
    private string sheepQuestText3 = "(sem miss�es)";

    //CORN QUEST
    private bool cornActive = false;
    private bool cornQuestDone = false;
    private string cornQuestText1 = "-> Colha todos os milhos na planta��o.";
    private string cornQuestText2 = "-> Coloque os milhos na carro�a.";
    private string cornQuestText3 = "-> Volte a falar com seu pai.";

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
    #endregion
}
