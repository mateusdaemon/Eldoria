using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepHerding : MonoBehaviour
{
    private GameObject parent;
    private GameObject playerRef;
    private bool runAway = false;
    private PlayerStats.Direction runAwayDir;
    private SheepState sheepState;

    public AudioSource sheepBea;
    public SheepGraze grazeBehavior;

    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent.gameObject;
        sheepState = parent.GetComponent<SheepState>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (runAway)
        {
            RunAwaySheep();            
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerRef = other.gameObject;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!sheepBea.isPlaying)
            {
                sheepBea.Play();
            }
            grazeBehavior.Graze(false);
            playerRef = other.gameObject;
            runAway = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerRef = null;
            runAway = false;
            grazeBehavior.Graze(true);
        }
    }

    private void RunAwaySheep()
    {
        float dist = Vector3.Distance(this.transform.position, playerRef.transform.position);
        float posX = transform.position.x;
        float posZ = transform.position.z;
        Vector3 playerPos = playerRef.transform.position;
        Vector3 sheepPos = this.transform.position;

        // Very difficult logic to get where sheep should go
        if (playerPos.x >= sheepPos.x - 1 && playerPos.x <= sheepPos.x + 1)
        {
            if (playerPos.z > sheepPos.z)
            {
                posZ -= dist;
                runAwayDir = PlayerStats.Direction.Front;
            }
            else
            {
                posZ += dist;
                runAwayDir = PlayerStats.Direction.Back;
            }
        }
        else if (playerPos.z >= sheepPos.z - 1 && playerPos.z <= sheepPos.z + 1)
        {
            if (playerPos.x > sheepPos.x)
            {
                posX -= dist;
                runAwayDir = PlayerStats.Direction.Left;
            }
            else
            {
                posX += dist;
                runAwayDir = PlayerStats.Direction.Right;
            }
        } 
        else if (playerPos.x > sheepPos.x)
        {
            if (playerPos.z > sheepPos.z)
            {
                posX -= dist;
                posZ -= dist;
            }
            else if (playerPos.z < sheepPos.z)
            {
                posX -= dist;
                posZ += dist;
            }
        }
        else if (playerPos.x < sheepPos.x)
        {
            if (playerPos.z > sheepPos.z)
            {
                posX += dist;
                posZ -= dist;
            }
            else if (playerPos.z < sheepPos.z)
            {
                posX += dist;
                posZ += dist;
            }
        }

        Vector3 target = new Vector3(posX, 0, posZ);

        OrientSheepAnim();

        parent.transform.position = Vector3.MoveTowards(transform.position, target, 0.1f);
    }

    private void OrientSheepAnim()
    {
        switch (runAwayDir)
        {
            case PlayerStats.Direction.Right:
                sheepState.SetSheepState(SheepState.ShipState.GoRight);
                break;
            case PlayerStats.Direction.Left:
                sheepState.SetSheepState(SheepState.ShipState.GoLeft);
                break;
            case PlayerStats.Direction.Front:
                sheepState.SetSheepState(SheepState.ShipState.GoFront);
                break;
            case PlayerStats.Direction.Back:
                sheepState.SetSheepState(SheepState.ShipState.GoBack);
                break;
            default:
                break;
        }
    }

}
