using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSleep : MonoBehaviour
{
    private SheepState sheepState;

    // Start is called before the first frame update
    void Start()
    {
        sheepState = GetComponent<SheepState>();
        sheepState.SetSheepState(SheepState.ShipState.Sleep);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
