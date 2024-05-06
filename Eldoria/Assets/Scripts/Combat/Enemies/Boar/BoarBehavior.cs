using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static WolfCrocState;

public class BoarBehavior : MonoBehaviour
{
    private Vector3 origin;
    private bool goToPlayer = false;
    private GameObject playerRef;
    private GameObject parent;
    private Vector3 moveTarget;
    private bool originSet = false;
    private bool isAttaking = false;
    private Enemy enemy;
    private bool threatened = false;
    private bool inRaige = false;

    public WolfCrocodileAttack attackArea;
    public GameObject warnSign;
    public GameObject dangerSign;
    public float attackDistance = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        parent = this.transform.parent.gameObject;
        enemy = parent.GetComponent<Enemy>();
        playerRef = GameObject.FindWithTag("Player");
        Invoke("SetOrigin", 1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // se move lentamente até o player quando ameaçado
        if (threatened && !inRaige)
        {
            Debug.Log("qq eu to vendo ai");
            moveTarget.x = playerRef.transform.position.x;
            moveTarget.z = playerRef.transform.position.z;
            parent.transform.position = Vector3.MoveTowards(parent.transform.position, moveTarget, 0.2f);
        }

        if (goToPlayer)
        {
            if (!isAttaking)
            {
                if (Vector3.Distance(transform.position, playerRef.transform.position) <= attackDistance)
                {
                    //AttackPlayer();
                    //isAttaking = true;
                    //Invoke("ResetIsAttacking", 2.0f);
                }
                else
                {
                    MoveToPlayer();
                }
            }
        }
        else
        {
            // If not going to player then return to origin position
            if (originSet && parent.transform.position != origin)
            {
                MoveToOrigin();
            }
            else
            {
                enemy.ResetLife();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        threatened = true;
        warnSign.SetActive(true);
        Invoke("SpotPlayer", 1.0f);
    }

    private void OnTriggerExit(Collider other)
    {
        goToPlayer = false;
        threatened = false;
        warnSign.SetActive(false);
        dangerSign.SetActive(false);
    }

    private void SetOrigin()
    {
        origin = transform.position;
        moveTarget = new Vector3(0, origin.y, 0);
        originSet = true;
    }

    private void SpotPlayer()
    {
        if (threatened)
        {
            warnSign.SetActive(false);
            dangerSign.SetActive(true);
            goToPlayer = true;
        }
    }

    private void MoveToPlayer()
    {
        //if (playerRef.transform.position.x > transform.position.x)
        //{

            
        //}
        //else
        //{
            
        //}

        moveTarget.x = playerRef.transform.position.x;
        moveTarget.z = playerRef.transform.position.z;
        parent.transform.position = Vector3.MoveTowards(parent.transform.position, moveTarget, 0.1f);
    }

    private void AttackPlayer()
    {
        bool hit = attackArea.AttackPlayer();

        if (hit)
        {
            enemy.AttackPlayer();
        }
    }

    private void MoveToOrigin()
    {
        //if (origin.x > parent.transform.position.x)
        //{

            
        //}
        //else
        //{
            
        //}

        parent.transform.position = Vector3.MoveTowards(parent.transform.position, origin, 0.15f);
    }


    private void ResetIsAttacking()
    {
        isAttaking = false;
    }
}
