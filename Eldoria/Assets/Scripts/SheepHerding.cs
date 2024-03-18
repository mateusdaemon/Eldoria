using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepHerding : MonoBehaviour
{
    private GameObject parent;
    private GameObject playerRef;
    private bool runAway = false;

    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent.gameObject;
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
        }
    }

    private void RunAwaySheep()
    {
        float dist = Vector3.Distance(this.transform.position, playerRef.transform.position);
        float posX = transform.position.x;
        float posZ = transform.position.z;
        Vector3 playerPos = playerRef.transform.position;
        Vector3 sheepPos = this.transform.position;
        Debug.Log(dist);

        if (playerPos.x >= sheepPos.x - 1 && playerPos.x <= sheepPos.x + 1)
        {
            if (playerPos.z > sheepPos.z)
            {
                posZ -= dist;
            }
            else
            {
                posZ += dist;
            }
        }
        else if (playerPos.z >= sheepPos.z - 1 && playerPos.z <= sheepPos.z + 1)
        {
            if (playerPos.x > sheepPos.x)
            {
                posX -= dist;
            }
            else
            {
                posX += dist;
            }
        } else if (playerPos.x > sheepPos.x)
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
        //else if (playerPos.x == sheepPos.x)
        //{
        //    if (playerPos.z > sheepPos.z)
        //    {
        //        posZ -= dist;
        //    } else
        //    {
        //        posZ += dist;
        //    }
        //} else if (playerPos.z == sheepPos.z)
        //{
        //    if (playerPos.x > sheepPos.x)
        //    {
        //        posX -= dist;
        //    }
        //    else
        //    {
        //        posX += dist;
        //    }
        //}

        Vector3 target = new Vector3(posX, 0, posZ);
        parent.transform.position = Vector3.MoveTowards(transform.position, target, 0.1f);
    }
}
