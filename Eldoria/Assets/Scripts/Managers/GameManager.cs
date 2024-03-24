using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public HudManager hudManager;
    public int maxFPS;

    private float shootManaCost = 1;

    // Quest indicators

    // SHEEP QUEST
    private bool sheepActive = false;
    private bool sheepQuestDone = false;
    private string sheepQuestText = "-> Procure as ovelhas e leve-as para dentro da fazenda.";

    //CORN QUEST
    private bool cornActive = false;
    private bool cornQuestDone = false;
    private string cornQuestText = "-> Colha todos os milhos na plantação e leve até a carroça.";

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = maxFPS;
    }

    public void SetShootCost(float cost)
    {
        shootManaCost = cost;
    }

    public void PlayerShoot()
    {
        PlayerStats.DropMana(shootManaCost);
        hudManager.SetManaAmount(PlayerStats.GetMana()/PlayerStats.GetMaxMana());
    }

    public void DrinkLifePot(float life)
    {
        hudManager.UseLifePot();
        PlayerStats.AddLife(life);
        hudManager.SetLifeAmout(PlayerStats.GetLife() / PlayerStats.GetMaxLife());
    }

    public void DrinkManaPot(float mana)
    {
        hudManager.UseManaPot();
        PlayerStats.AddMana(mana);
        hudManager.SetManaAmount(PlayerStats.GetMana() / PlayerStats.GetMaxMana());
    }

    public void EnableLifePot()
    {
        hudManager.ActivateLifePot();
    }

    public void EnableManaPot()
    {
        hudManager.ActivateManaPot();
    }

    public void AttackPlayer(float damage)
    {
        PlayerStats.DropLife(damage);
        hudManager.SetLifeAmout(PlayerStats.GetLife() / PlayerStats.GetMaxLife());
    }

    public void ActiveSheepQuest()
    {
        sheepActive = true;
        hudManager.SetQuestText(sheepQuestText);
    }

    public bool GetSheepActive()
    {
        return sheepActive;
    }

    public bool SheepQuestDone()
    {
        return sheepQuestDone;
    }

    public void ActiveCornQuest()
    {
        cornActive = true;
        hudManager.SetQuestText(cornQuestText);
    }

    public void SetSheepQuestDone(bool done)
    {
        sheepQuestDone = done;
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
}
