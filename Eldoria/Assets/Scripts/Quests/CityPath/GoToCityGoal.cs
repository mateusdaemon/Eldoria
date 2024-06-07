using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToCityGoal : MonoBehaviour
{
    public Quest questRelated;
    public Goal goal;
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
        if (other.gameObject.CompareTag("Player"))
        {
            if (!goal.Complete())
            {
                goal.AddAmount();

                if (goal.CheckComplete())
                {
                    goal.CompleteGoal();
                    questRelated.CheckForComplete();
                }
            }
        }
    }
}
