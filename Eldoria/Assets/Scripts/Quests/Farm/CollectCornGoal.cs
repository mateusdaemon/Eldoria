using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCornGoal : MonoBehaviour
{
    public Quest questRelated;
    public Goal goal;
    public HudManager hudManager;
    public GameObject interactionUI;
    public GameObject plantGroup;
    public GameObject cornGroup;
    public ParticleSystem cornParticle;
    public GameObject wagonGoalObject;
    
    private GameManager gameManager;
    private bool canCollect = false;
    private Vector3 particleSplashPos;

    // Start is called before the first frame update
    void Start()
    {
        particleSplashPos = transform.position;
        particleSplashPos.y = 3.0f;
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canCollect && Input.GetKeyDown(KeyCode.F))
        {
            CollectCorn();
            cornGroup.SetActive(false);
            plantGroup.transform.Translate(new Vector3(0, -1, 0));
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (questRelated.active)
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
        ParticleSystem corn = Instantiate(cornParticle, particleSplashPos, cornParticle.transform.rotation);
        corn.Play();

        gameManager.sm.PlaySfx(gameManager.sm.corn);

        goal.AddAmount();

        string goalDesc = goal.description + "(" + goal.GetAmount() + "/" + goal.GetReqAmount() + ")";
        hudManager.SetQuestText(goalDesc);

        if (goal.CheckComplete())
        {
            wagonGoalObject.SetActive(true);
            goal.CompleteGoal();
            questRelated.CheckForComplete();
        }
    }
}
