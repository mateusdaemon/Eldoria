using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepInsideGoal : MonoBehaviour
{
    public Quest questRelated;
    public Goal goal;
    public HudManager hudManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sheep"))
        {
            goal.AddAmount();
            string goalDesc = goal.description + "(" + goal.GetAmount() + "/" + goal.GetReqAmount() + ")";
            hudManager.SetQuestText(goalDesc);
            
            if (goal.CheckComplete())
            {
                goal.CompleteGoal();
                questRelated.CheckForComplete();
            }
        }
    }
}
