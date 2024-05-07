using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoarBehavior : MonoBehaviour
{
    private BoarState boarState;
    private Vector3 origin;
    private GameObject playerRef;
    private GameObject parent;
    private Vector3 moveTarget;
    private bool originSet = false;
    private bool isAttaking = false;
    private Enemy enemy;
    private bool threatened = false;
    private bool inRaige = false;
    private bool canRaige = true;

    public WolfCrocodileAttack attackArea;
    public GameObject warnSign;
    public GameObject dangerSign;
    public float attackDistance = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        parent = this.transform.parent.gameObject;
        enemy = parent.GetComponent<Enemy>();
        boarState = parent.GetComponent<BoarState>();
        playerRef = GameObject.FindWithTag("Player");
        Invoke("SetOrigin", 1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // se move lentamente at� o player quando amea�ado
        if (threatened && !inRaige && !isAttaking)
        {
            moveTarget.x = playerRef.transform.position.x;
            moveTarget.z = playerRef.transform.position.z;

            if (Vector3.Distance(parent.transform.position, moveTarget) <= 8.0f && canRaige)
            {
                inRaige = true;
                canRaige = false;

            } else if (Vector3.Distance(parent.transform.position, moveTarget) > 3.0f)
            {
                Debug.Log("indo at� o player...");
                MoveToPlayer();
            } else
            {
                Debug.Log("Ataqueee");
                boarState.ChangeState(BoarState.State.Attack);
                isAttaking = true;
                Invoke("ResetIsAttacking", 1.5f);
            }
            
        } else if (inRaige)
        {
            if (Vector3.Distance(parent.transform.position, moveTarget) > 3.0f)
            {
                boarState.ChangeState(BoarState.State.Raige);
                parent.transform.position = Vector3.MoveTowards(parent.transform.position, moveTarget, 0.2f);

            } else
            {
                Debug.Log("Ataque raige");
                boarState.ChangeState(BoarState.State.Attack);
                inRaige = false;
                canRaige = false;
                isAttaking = true;
                Invoke("ResetIsAttacking", 1.5f);
                Invoke("ResetCanRaige", 2.0f);
            }
        }
        else if (!threatened)
        {
            // If not going to player then return to origin position
            if (Vector3.Distance(parent.transform.position, origin) > 0.5f && originSet)
            {
                Debug.Log("Go to origin");
                MoveToOrigin();
            }
            else
            {
                Debug.Log("Recuperando vida ...");
                enemy.ResetLife();
                boarState.ChangeState(BoarState.State.Idle);
            }
        } else
        {
            Debug.Log("Vo fica deboa");
            boarState.ChangeState(BoarState.State.Idle);
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
        }
    }

    private void MoveToPlayer()
    {
        if (playerRef.transform.position.x > transform.position.x)
        {
            boarState.ChangeState(BoarState.State.GoRight);
        }
        else
        {
            boarState.ChangeState(BoarState.State.GoLeft);
        }

        parent.transform.position = Vector3.MoveTowards(parent.transform.position, moveTarget, 0.1f);
    }

    private void MoveToOrigin()
    {
        if (origin.x > parent.transform.position.x)
        {
            boarState.ChangeState(BoarState.State.GoRight);
        }
        else
        {
            boarState.ChangeState(BoarState.State.GoLeft);
        }

        parent.transform.position = Vector3.MoveTowards(parent.transform.position, origin, 0.15f);
    }


    private void ResetIsAttacking()
    {
        isAttaking = false;
    }

    private void ResetCanRaige()
    {
        canRaige = true;
    }
}
