using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchBookGoal : MonoBehaviour
{
    public Quest questRelated;
    public Goal goal;
    public GameObject interactionUI;

    private bool canInteract = false;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.F))
        {
            PlayerStats.EnableSkill(true);
            gameManager.LoadScene("FarmTransition");

            goal.AddAmount();
            if (goal.CheckComplete())
            {
                goal.CompleteGoal();
                questRelated.CheckForComplete();
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
