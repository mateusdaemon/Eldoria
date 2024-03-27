using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfCrocodileAttack : MonoBehaviour
{
    [Header("---Manager---")]
    public GameManager gm;
    public SoundManager sm;

    [Header("---WolfCrocodile---")]
    public Enemy enemyStats;
    public bool hitPlayer;
    public GameObject spriteEnemy;


    private Animator anim;

    private void Start()
    {
        anim = spriteEnemy.GetComponent<Animator>();
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

    public void AttackPlayer(Enemy currEnemy)
    {
        anim.SetBool("attack", true);
        Invoke("DisableAttack", anim.GetCurrentAnimatorClipInfo(0).Length);
        sm.PlaySfx(sm.wolfBarkSound);
        
        bool hit = !PlayerStats.IsNeutralShielded();

        if (hit)
        {
            gm.AttackPlayer(enemyStats.damage);
        }
    }

    private void DisableAttack()
    {
        anim.SetBool("attack", false);
    }
}
