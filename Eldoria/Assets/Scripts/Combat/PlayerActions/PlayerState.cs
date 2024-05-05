using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State { 
    Idle, 
    Walk, 
    Run, 
    Dodge, 
    Attack, 
    Stuck,
    Dialogue
}

public class PlayerState : MonoBehaviour
{
    [Header("Animation Objects")]
    public GameObject animatedFront;
    public GameObject animatedBack;
    public GameObject animatedRight;
    public GameObject animatedLeft;

    private State currState;

    // Start is called before the first frame update
    void Start()
    {
        currState = State.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currState)
        {
            case State.Idle:
                break;
            case State.Walk:
                //AnimateWalkWithDir();
                break;
            case State.Run:
                break;
            case State.Dodge:
                break;
            case State.Attack:
                break;
            case State.Stuck:
                break;
            case State.Dialogue:
                break;
        }
    }

    public void ChangeState(State state)
    {
        switch(state)
        {
            case State.Idle:
                currState = State.Idle;
                break;
            case State.Walk:
                if (currState != State.Stuck && currState != State.Dialogue)
                {
                    currState = State.Walk;
                }
                break;
            case State.Run:
                if (currState != State.Stuck && currState != State.Dialogue)
                {
                    currState = State.Run;
                }
                break;
            case State.Dodge:
                if (currState != State.Dialogue)
                {
                    currState = State.Dodge;
                }                
                break;
            case State.Attack:
                if (currState != State.Stuck && currState != State.Dialogue)
                {
                    currState = State.Attack;
                }                
                break;
            case State.Stuck:
                currState = State.Stuck;
                break;
            case State.Dialogue:
                currState = State.Dialogue;
                break;
        }
    }

    private void AnimateWalkWithDir()
    {
        if (animatedFront.activeSelf) { animatedFront.GetComponent<Animator>().SetBool("walk", false); }
        if (animatedBack.activeSelf) { animatedBack.GetComponent<Animator>().SetBool("walk", false); }
        if (animatedRight.activeSelf) { animatedRight.GetComponent<Animator>().SetBool("walk", false); }
        if (animatedLeft.activeSelf) { animatedLeft.GetComponent<Animator>().SetBool("walk", false); }
    }
}
