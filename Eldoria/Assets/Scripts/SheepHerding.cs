using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepHerding : MonoBehaviour
{
    private GameObject parent;
    private GameObject playerRef;
    private bool runAway = false;
    private PlayerStats.Direction runAwayDir;
    private Animator parentAnim;
    private SpriteRenderer parentSr;

    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent.gameObject;
        parentAnim = parent.GetComponent<Animator>();
        parentSr = parent.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (runAway)
        {
            RunAwaySheep();            
        } else
        {
            parentAnim.SetBool("frontWalk", false);
            parentAnim.SetBool("backWalk", false);
            parentAnim.SetBool("sideWalk", false);
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

        OrientSheepSprite();

        parent.transform.position = Vector3.MoveTowards(transform.position, target, 0.1f);
    }

    private void OrientSheepSprite()
    {
        switch (runAwayDir)
        {
            case PlayerStats.Direction.Right:
                parentAnim.SetBool("frontWalk", false);
                parentAnim.SetBool("backWalk", false);
                parentAnim.SetBool("sideWalk", true);
                parentSr.flipX = true;
                break;
            case PlayerStats.Direction.Left:
                parentAnim.SetBool("frontWalk", false);
                parentAnim.SetBool("backWalk", false);
                parentAnim.SetBool("sideWalk", true);
                parentSr.flipX = false;
                break;
            case PlayerStats.Direction.Front:
                parentAnim.SetBool("frontWalk", true);
                parentAnim.SetBool("backWalk", false);
                parentAnim.SetBool("sideWalk", false);
                break;
            case PlayerStats.Direction.Back:
                parentAnim.SetBool("frontWalk", false);
                parentAnim.SetBool("backWalk", true);
                parentAnim.SetBool("sideWalk", false);
                break;
            default:
                break;
        }
    }
}
