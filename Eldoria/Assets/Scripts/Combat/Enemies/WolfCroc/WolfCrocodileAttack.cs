using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfCrocodileAttack : MonoBehaviour
{
    [Header("---Manager---")]
    public GameManager gm;
    public SoundManager sm;

    [Header("---WolfCrocodile---")]
    public bool hitPlayer;

    private Enemy enemy;
    private WolfCrocState wolfState;

    private void Start()
    {
        enemy = gameObject.GetComponentInParent<Enemy>();
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
        if (hitPlayer)
        {
            wolfState.SetWolfState(WolfCrocState.WolfState.Attack);
            sm.PlaySfx(sm.wolfBarkSound);
            Invoke("DisableAttack", 0.5f);
            enemy.AttackPlayer();
        }

        return hitPlayer;
    }

    private void DisableAttack()
    {
        wolfState.SetWolfState(WolfCrocState.WolfState.Idle);
    }
}
