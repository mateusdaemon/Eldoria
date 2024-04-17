using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfCrocState : MonoBehaviour
{
    public enum WolfState { Idle, GoRight, GoLeft, Attack, Dodge, None};
    public Animator wolfAnimator;
    public SpriteRenderer wolfSprite;
    private WolfState lastState = WolfState.None;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetWolfState(WolfState state)
    {
        if (lastState == state) return;

        wolfAnimator.SetBool("walk", false);
        wolfAnimator.SetBool("walk", false);
        wolfAnimator.SetBool("attack", false);

        switch (state)
        {
            case WolfState.Idle:
                break;
            case WolfState.GoRight:
                wolfSprite.flipX = true;
                wolfAnimator.SetBool("walk", true);
                break;
            case WolfState.GoLeft:
                wolfSprite.flipX = false;
                wolfAnimator.SetBool("walk", true);
                break;
            case WolfState.Attack:
                wolfAnimator.SetBool("attack", true);
                break;
            case WolfState.Dodge:
                wolfAnimator.SetTrigger("dodge");
                break;
            default:
                break;
        }

        lastState = state;
    }
}
