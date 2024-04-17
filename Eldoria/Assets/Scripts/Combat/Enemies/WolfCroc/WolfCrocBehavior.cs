using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfCrocBehavior : MonoBehaviour
{
    private Vector3 origin;
    private bool goToPlayer = false;
    private GameObject playerRef;
    private GameObject parent;
    private Vector3 moveTarget;
    private bool originSet = false;
    private bool isAttaking = false;
    private WolfCrocState wolfState;
    private Enemy enemy;

    public WolfCrocodileAttack attackArea;
    public GameObject warnSign;
    public GameObject dangerSign;

    // Start is called before the first frame update
    void Start()
    {
        parent = this.transform.parent.gameObject;
        enemy = parent.GetComponent<Enemy>();
        wolfState = parent.GetComponent<WolfCrocState>();
        Invoke("SetOrigin", 1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (goToPlayer)
        {
            if (!isAttaking)
            {
                if (!attackArea.hitPlayer)
                {
                    MoveToPlayer();
                } else
                {
                    Invoke("AttackPlayer", 0);
                    isAttaking = true;
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
                wolfState.SetWolfState(WolfCrocState.WolfState.Idle);
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

    private void SpotPlayer()
    {
        if (playerRef != null)
        {
            warnSign.SetActive(false);
            dangerSign.SetActive(true);
            goToPlayer = true;
        }
    }

    private void MoveToPlayer()
    {
        if (playerRef.transform.position.x > transform.position.x)
        {

            wolfState.SetWolfState(WolfCrocState.WolfState.GoRight);
        }
        else
        {
            wolfState.SetWolfState(WolfCrocState.WolfState.GoLeft);
        }

        moveTarget.x = playerRef.transform.position.x;
        moveTarget.z = playerRef.transform.position.z;
        parent.transform.position = Vector3.MoveTowards(parent.transform.position, moveTarget, 0.15f);
    }

    private void AttackPlayer()
    {
        if (!attackArea.AttackPlayer())
        {
            isAttaking = false;
        } else
        {
            Invoke("AttackPlayer", 2.0f);
        }
    }

    private void MoveToOrigin()
    {
        if (origin.x > parent.transform.position.x)
        {

            wolfState.SetWolfState(WolfCrocState.WolfState.GoRight);
        }
        else
        {
            wolfState.SetWolfState(WolfCrocState.WolfState.GoLeft);
        }

        parent.transform.position = Vector3.MoveTowards(parent.transform.position, origin, 0.15f);
    }

    public GameObject GetPlayerRef()
    {
        return playerRef;
    }

}
