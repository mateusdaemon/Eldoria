using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarState : MonoBehaviour
{
    public enum State { Idle, GoRight, GoLeft, Attack, Raige, None};
    public Animator wolfAnimator;
    public SpriteRenderer wolfSprite;
    private State lastState = State.None;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetWolfState(State state)
    {
        if (lastState == state) return;

        wolfAnimator.SetBool("walk", false);
        wolfAnimator.SetBool("attack", false);

        switch (state)
        {
            case State.Idle:
                break;
            case State.GoRight:
                wolfSprite.flipX = true;
                wolfAnimator.SetBool("walk", true);
                break;
            case State.GoLeft:
                wolfSprite.flipX = false;
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

        lastState = state;
    }
}
