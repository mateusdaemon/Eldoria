using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public string description;
    public int reqAmount = 0;
    private bool complete = false;
    private int currAmount = 0;

    public bool CheckComplete()
    {
        return currAmount >= reqAmount;
    }

    public void CompleteGoal()
    {
        complete = true;
    }
}
