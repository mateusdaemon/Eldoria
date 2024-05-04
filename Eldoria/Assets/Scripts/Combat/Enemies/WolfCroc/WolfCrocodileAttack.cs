using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfCrocodileAttack : MonoBehaviour
{
    private bool hitPlayer;
    private WolfCrocState wolfState;
    private GameManager gm;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        wolfState = GetComponentInParent<WolfCrocState>();
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

    public bool AttackPlayer()
    {
        wolfState.SetWolfState(WolfCrocState.WolfState.Attack);
        gm.sm.PlaySfx(gm.sm.wolfBarkSound);
        Invoke("DisableAttack", 0.5f);

        return hitPlayer;
    }

    private void DisableAttack()
    {
        wolfState.SetWolfState(WolfCrocState.WolfState.Idle);
    }
}
