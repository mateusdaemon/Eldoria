using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillChiefGoal : MonoBehaviour
{
    public Quest questRelated;
    public Goal goal;
    public GameObject nextGoal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        goal.AddAmount();

        if (goal.CheckComplete())
        {
            goal.CompleteGoal();
            questRelated.CheckForComplete();
            nextGoal.SetActive(true);
        }       
    }
}
