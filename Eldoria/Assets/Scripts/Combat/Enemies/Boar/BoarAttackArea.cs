using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarAttackArea : MonoBehaviour
{
    private bool hitPlayer;

    private void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hitPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hitPlayer = false;
        }
    }

    public bool HitPlayer()
    {
        return hitPlayer;
    }
}
