using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarState : MonoBehaviour
{
    public enum State { Idle, GoRight, GoLeft, Attack, Raige, None};
    public Animator wolfAnimator;
    public SpriteRenderer wolfSprite;
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
                break;
            case State.GoRight:
                wolfSprite.flipX = false;
                wolfAnimator.SetBool("walk", true);
                break;
            case State.GoLeft:
                wolfSprite.flipX = true;
                wolfAnimator.SetBool("walk", true);
                break;
            case State.Attack:
                wolfAnimator.SetBool("attack", true);
                break;
            case State.Raige:
                wolfAnimator.SetBool("raige", true);
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
                if (currState != State.Attack && currState != State.Raige)
                {
                    currState = State.GoRight;
                }
                break;
            case State.GoLeft:
                if (currState != State.Attack && currState != State.Raige)
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
