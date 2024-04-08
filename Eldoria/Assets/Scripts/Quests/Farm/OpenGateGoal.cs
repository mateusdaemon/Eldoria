using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGateGoal : MonoBehaviour
{
    public Quest sheepQuest;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (sheepQuest.active)
        {
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePosition;
        }        
    }
}
