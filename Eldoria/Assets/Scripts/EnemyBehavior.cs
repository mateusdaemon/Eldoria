using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private Vector3 origin;
    private bool goToPlayer = false;
    private GameObject playerRef;
    private GameObject parent;
    private Vector3 moveTarget;
    private bool originSet = false;
    private bool isAttaking = false;
    private SpriteRenderer sr;
    private Animator anim;

    public float distancePlayer;
    public DamagePlayer attackArea;
    public GameObject sprite;
    public GameObject warnSign;
    public GameObject dangerSign;

    // Start is called before the first frame update
    void Start()
    {
        parent = this.transform.parent.gameObject;
        sr = sprite.GetComponent<SpriteRenderer>();
        anim = sprite.GetComponent<Animator>();
        Invoke("SetOrigin", 1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (goToPlayer)
        {
            if (!isAttaking && Vector3.Distance(parent.transform.position, playerRef.transform.position) > distancePlayer)
            {
                anim.SetBool("walk", true);
                if (playerRef.transform.position.x > transform.position.x)
                {
                    sr.flipX = true;
                } else
                {
                    sr.flipX = false;
                }
                moveTarget.x = playerRef.transform.position.x;
                moveTarget.z = playerRef.transform.position.z;
                parent.transform.position = Vector3.MoveTowards(parent.transform.position, moveTarget, 0.15f);
            } else
            {
                anim.SetBool("walk", false);
                if (!isAttaking)
                {
                    isAttaking = true;
                    Invoke("AttackPlayer", 0);
                }
            }
        } else
        {
            if (originSet && parent.transform.position != origin)
            {
                anim.SetBool("walk", true);
                parent.transform.position = Vector3.MoveTowards(parent.transform.position, origin, 0.15f);
            } else
            {
                anim.SetBool("walk", false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        warnSign.SetActive(true);
        Invoke("SpotPlayer", 1.0f);
        playerRef = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        CancelInvoke();
        goToPlayer = false;
        warnSign.SetActive(false);
        dangerSign.SetActive(false);
        playerRef = null;
    }

    private void SetOrigin()
    {
        origin = transform.position;
        moveTarget = new Vector3(0, origin.y, 0);
        originSet = true;
    }

    private void AttackPlayer()
    {
        if (attackArea.hitPlayer)
        {
            attackArea.AttackPlayer(parent.GetComponent<Enemy>());
            Invoke("AttackPlayer", 2.0f);
        } else
        {
            isAttaking = false;
        }
    }

    private void SpotPlayer()
    {
        if (playerRef != null)
        {
            warnSign.SetActive(false);
            dangerSign.SetActive(true);
            goToPlayer = true;
        }
    }
}
