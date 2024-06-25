using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetForestBookGoal : MonoBehaviour
{
    public Quest questRelated;
    public Goal goal;
    public GameObject interact;
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
            if (!goal.Complete())
            {
                goal.AddAmount();

                if (goal.CheckComplete())
                {
                    gameManager.LoadScene("ForestBookTransition");
                    goal.CompleteGoal();
                    questRelated.CheckForComplete();
                    Destroy(gameObject);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            interact.SetActive(true);
            canInteract = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            interact.SetActive(false);
            canInteract = false;
        }
    }
}
