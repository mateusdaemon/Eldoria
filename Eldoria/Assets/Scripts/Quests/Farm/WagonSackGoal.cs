using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WagonSackGoal : MonoBehaviour
{
    public Quest questRelated;
    public Goal goal;
    public HudManager hudManager;
    public GameObject interactionUI;
    public GameObject sack;

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
            PlaceSack();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (questRelated.enable)
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

    private void PlaceSack()
    {
        goal.AddAmount();
        sack.SetActive(true);

        if (goal.CheckComplete())
        {
            goal.CompleteGoal();
            questRelated.CheckForComplete();
        }
    }
}
