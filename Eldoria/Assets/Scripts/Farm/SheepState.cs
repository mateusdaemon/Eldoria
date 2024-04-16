using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepState : MonoBehaviour
{
    public GameObject animatedFront, animatedBack, animatedRight, animatedLeft;
    public enum ShipState { Graze, Idle, GoBack, GoFront, GoLeft, GoRight }

    private GameObject currentAnim;
    private ShipState currState = ShipState.Idle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSheepState(ShipState state)
    {
        if (state != currState && state != ShipState.Graze && state != ShipState.Idle)
        {
            if (currentAnim != null)
            {
                currentAnim.GetComponent<Animator>().SetBool("graze", false);
            }
            
            animatedBack.SetActive(false);
            animatedLeft.SetActive(false);
            animatedFront.SetActive(false);
            animatedRight.SetActive(false);
        }

        switch (state)
        {
            case ShipState.Graze:
                currentAnim.GetComponent<Animator>().SetBool("graze", true);
                currState = ShipState.Graze;
                break;
            case ShipState.Idle:
                currentAnim.GetComponent<Animator>().SetBool("idle", true);
                currState = ShipState.Idle;
                break;
            case ShipState.GoBack:
                animatedBack.SetActive(true);
                currentAnim = animatedBack;
                currState = ShipState.GoBack;
                break;
            case ShipState.GoFront:
                animatedFront.SetActive(true);
                currentAnim = animatedFront;
                currState = ShipState.GoFront;
                break;
            case ShipState.GoLeft:
                animatedLeft.SetActive(true);
                currentAnim = animatedLeft;
                currState = ShipState.GoLeft;
                break;
            case ShipState.GoRight:
                animatedRight.SetActive(true);
                currentAnim = animatedRight;
                currState = ShipState.GoRight;
                break;
            default:
                break;
                    
        }
    }

    public SheepState.ShipState GetSheepState()
    {
        return currState;
    }


}
