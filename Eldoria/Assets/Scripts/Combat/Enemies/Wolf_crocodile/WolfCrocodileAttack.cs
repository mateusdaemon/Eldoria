using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfCrocodileAttack : MonoBehaviour
{
    public GameManager gm;
    public Enemy enemyStats;
    public bool hitPlayer;
    public GameObject spriteEnemy;
    public AudioSource sfxBark;

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
        sfxBark.Play();
        
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
