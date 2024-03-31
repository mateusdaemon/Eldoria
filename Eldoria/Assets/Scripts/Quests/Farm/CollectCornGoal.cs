using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCornGoal : MonoBehaviour
{
    public Quest questRelated;
    public Goal goal;
    public HudManager hudManager;
    public GameObject interactionUI;
    public ParticleSystem cornParticle;
    public GameObject wagonGoalObject;

    private bool canCollect = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canCollect && Input.GetKeyDown(KeyCode.F))
        {
            CollectCorn();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (questRelated.enable)
            {
                canCollect = true;
                interactionUI.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canCollect = false;
            interactionUI.SetActive(false);
        }
    }

    private void CollectCorn()
    {
        ParticleSystem corn = Instantiate(cornParticle, transform.position, new Quaternion());
        corn.Play();

        goal.AddAmount();

        string goalDesc = goal.description + "(" + goal.GetAmount() + "/" + goal.GetReqAmount() + ")";
        hudManager.SetQuestText(goalDesc);

        if (goal.CheckComplete())
        {
            //wagonGoalObject.SetActive(true);
            goal.CompleteGoal();
            questRelated.CheckForComplete();
        }
    }
}
