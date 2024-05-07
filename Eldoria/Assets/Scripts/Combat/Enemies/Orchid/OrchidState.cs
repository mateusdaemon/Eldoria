using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrchidState : MonoBehaviour
{
    public enum PlantState { Idle, Attack};
    public Animator plantAnim;
    private PlantState currState = PlantState.Idle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(currState)
        {
            case PlantState.Idle:
                plantAnim.SetBool("idle", true);
                plantAnim.SetBool("attack", false);
                break;
            case PlantState.Attack:
                plantAnim.SetBool("attack", true);
                plantAnim.SetBool("idle", false);
                break;
        }        
    }

    public void ChangeState(PlantState state)
    {
        switch (state)
        {
            case PlantState.Idle:
                currState = PlantState.Idle;
                break;
            case PlantState.Attack:
                currState = PlantState.Attack;
                break;
        }
    }
}
