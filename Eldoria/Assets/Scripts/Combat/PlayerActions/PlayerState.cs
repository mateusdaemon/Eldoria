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
    Dialogue,
    None
}

public class PlayerState : MonoBehaviour
{
    [Header("Animation Objects")]
    public GameObject animatedFront;
    public GameObject animatedBack;
    public GameObject animatedRight;
    public GameObject animatedLeft;


    private GameObject currObject;
    private State currState;

    // Start is called before the first frame update
    void Start()
    {
        currState = State.Idle;
        animatedRight.SetActive(true);
        animatedLeft.SetActive(false);
        animatedBack.SetActive(false);
        animatedFront.SetActive(false);
        currObject = animatedRight;
    }

    // Update is called once per frame
    void Update()
    {
        EnableCurrent();

        switch (currState)
        {
            case State.Idle:
                currObject.GetComponent<Animator>().SetBool("idle", true);
                currObject.GetComponent<Animator>().SetBool("walk", false);
                currObject.GetComponent<Animator>().SetBool("run", false);
                currObject.GetComponent<Animator>().SetBool("dodge", false);
                break;
            case State.Walk:
                currObject.GetComponent<Animator>().SetBool("walk", true);
                currObject.GetComponent<Animator>().SetBool("idle", false);
                currObject.GetComponent<Animator>().SetBool("run", false);
                currObject.GetComponent<Animator>().SetBool("dodge", false);
                break;
            case State.Run:
                currObject.GetComponent<Animator>().SetBool("run", true);
                currObject.GetComponent<Animator>().SetBool("walk", false);
                currObject.GetComponent<Animator>().SetBool("idle", false);
                currObject.GetComponent<Animator>().SetBool("dodge", false);
                break;
            case State.Dodge:
                currObject.GetComponent<Animator>().SetBool("dodge", true);
                currObject.GetComponent<Animator>().SetBool("run", false);
                currObject.GetComponent<Animator>().SetBool("walk", false);
                currObject.GetComponent<Animator>().SetBool("idle", false);
                break;
            case State.Attack:
                break;
            case State.Stuck:
                currObject.GetComponent<Animator>().SetBool("idle", true);
                currObject.GetComponent<Animator>().SetBool("walk", false);
                currObject.GetComponent<Animator>().SetBool("run", false);
                currObject.GetComponent<Animator>().SetBool("dodge", false);
                break;
            case State.Dialogue:
                currObject.GetComponent<Animator>().SetBool("idle", true);
                currObject.GetComponent<Animator>().SetBool("walk", false);
                currObject.GetComponent<Animator>().SetBool("run", false);
                currObject.GetComponent<Animator>().SetBool("dodge", false);
                break;
            case State.None:
                currObject.GetComponent<Animator>().SetBool("idle", true);
                currObject.GetComponent<Animator>().SetBool("walk", false);
                currObject.GetComponent<Animator>().SetBool("run", false);
                currObject.GetComponent<Animator>().SetBool("dodge", false);
                break;
        }
    }

    public void ChangeState(State state)
    {
        switch(state)
        {
            case State.Idle:
                if (currState != State.Dodge)
                {
                    currState = State.Idle;
                }
                break;
            case State.Walk:
                if (currState != State.Stuck && currState != State.Dodge)
                {
                    currState = State.Walk;
                }
                break;
            case State.Run:
                if (currState != State.Stuck && currState != State.Dodge)
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
            case State.None:
                currState = State.None;
                break;
        }
    }

    private void EnableCurrent()
    {
        switch (PlayerStats.FacingDir())
        {
            case PlayerStats.Direction.Front:
                if (!animatedFront.activeSelf)
                {
                    currObject = animatedFront;
                    animatedFront.SetActive(true);
                    animatedRight.SetActive(false);
                    animatedLeft.SetActive(false);
                    animatedBack.SetActive(false);
                }
                break;
            case PlayerStats.Direction.Back:
                if (!animatedBack.activeSelf)
                {
                    currObject = animatedBack;
                    animatedFront.SetActive(false);
                    animatedRight.SetActive(false);
                    animatedLeft.SetActive(false);
                    animatedBack.SetActive(true);
                }
                break;
            case PlayerStats.Direction.Right:
                if (!animatedRight.activeSelf)
                {
                    currObject = animatedRight;
                    animatedFront.SetActive(false);
                    animatedRight.SetActive(true);
                    animatedLeft.SetActive(false);
                    animatedBack.SetActive(false);
                }
                break;
            case PlayerStats.Direction.Left:
                if (!animatedLeft.activeSelf)
                {
                    currObject = animatedLeft;
                    animatedFront.SetActive(false);
                    animatedRight.SetActive(false);
                    animatedLeft.SetActive(true);
                    animatedBack.SetActive(false);
                }
                break;
        }
    }

    public State GetState()
    {
        return currState;
    }
}
