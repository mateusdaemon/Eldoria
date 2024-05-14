using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchBookGoal : MonoBehaviour
{
    public Quest questRelated;
    public Goal goal;
    public GameObject interactionUI;
    public HudManager hudManager;
    public GameObject bookModel;
    public ParticleSystem catchFeedback;
    public GameObject bookAura;

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
            catchFeedback.Play();
            hudManager.ActivateNeutralBook();
            hudManager.ActivateCombatObjects();
            PlayerStats.EnableSkill(true);
            Destroy(bookAura);

            goal.AddAmount();
            if (goal.CheckComplete())
            {
                goal.CompleteGoal();
                questRelated.CheckForComplete();
                bookModel.SetActive(false);
                Destroy(gameObject);
            }
        }        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (questRelated.active)
            {
                canInteract = true;
                interactionUI.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = false;
            interactionUI.SetActive(false);
        }
    }
}
