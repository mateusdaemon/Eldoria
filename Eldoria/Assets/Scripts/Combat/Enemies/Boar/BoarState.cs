using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarState : MonoBehaviour
{
    public enum State { Idle, GoRight, GoLeft, Attack, Raige, None};
    public Animator boarAnimator;
    public SpriteRenderer boarSprite;
    private State currState = State.None;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (currState)
        {
            case State.Idle:
                boarAnimator.SetBool("idle", true);
                boarAnimator.SetBool("walk", false);
                boarAnimator.SetBool("attack", false);
                boarAnimator.SetBool("raige", false);
                break;
            case State.GoRight:
                boarSprite.flipX = false;
                boarAnimator.SetBool("walk", true);
                boarAnimator.SetBool("attack", false);
                boarAnimator.SetBool("raige", false);
                boarAnimator.SetBool("idle", false);
                break;
            case State.GoLeft:
                boarSprite.flipX = true;
                boarAnimator.SetBool("walk", true);
                boarAnimator.SetBool("attack", false);
                boarAnimator.SetBool("raige", false);
                boarAnimator.SetBool("idle", false);
                break;
            case State.Attack:
                boarAnimator.SetBool("attack", true);
                boarAnimator.SetBool("raige", false);
                boarAnimator.SetBool("walk", false);
                boarAnimator.SetBool("idle", false);
                break;
            case State.Raige:
                boarAnimator.SetBool("raige", true);
                boarAnimator.SetBool("walk", false);
                break;
            default:
                break;
        }

    }

    public void ChangeState(BoarState.State state)
    {
        switch (state)
        {
            case State.Idle:
                currState = State.Idle;
                break;
            case State.GoRight:
                if (currState != State.Raige)
                {
                    currState = State.GoRight;
                }
                break;
            case State.GoLeft:
                if (currState != State.Raige)
                {
                    currState = State.GoLeft;
                }
                break;
            case State.Attack:
                currState = State.Attack;
                break;
            case State.Raige:
                currState = State.Raige;
                break;
            default:
                break;
        }
    }
}
