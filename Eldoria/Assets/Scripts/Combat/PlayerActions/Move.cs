using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody rb;
    private float xDir, zDir;
    //private Animator anim;
    //private SpriteRenderer sr;

    public float velocity;
    public GameObject playerSpriteObj;
    public GameObject animatedFront, animatedBack, animatedRight, animatedLeft;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        //anim = playerSpriteObj.GetComponent<Animator>();
        //sr = playerSpriteObj.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!PlayerStats.CanMove())
        {
            return;
        }

        xDir = Input.GetAxis("Horizontal");
        zDir = Input.GetAxis("Vertical");

        if (xDir != 0 || zDir != 0)
        {
            OrientPlayerSprite();
            rb.AddForce(new Vector3(xDir, 0, zDir) * velocity);
        }

        //rb.velocity = new Vector3(xDir, 0, zDir) * velocity;
    }


    private void OrientPlayerSprite()
    {
        PlayerStats.Direction dir = PlayerStats.Direction.Front;


        if (xDir < 0)
        {
            // walk left
            animatedLeft.SetActive(true);
            animatedRight.SetActive(false);
            animatedBack.SetActive(false);
            animatedFront.SetActive(false);
            dir = PlayerStats.Direction.Left;
        }
        else if (xDir > 0)
        {
            // walk right
            animatedLeft.SetActive(false);
            animatedRight.SetActive(true);
            animatedBack.SetActive(false);
            animatedFront.SetActive(false);
            dir = PlayerStats.Direction.Right;
        }
        else if (zDir > xDir)
        {
            // walk back
            animatedRight.SetActive(false);
            animatedLeft.SetActive(false);
            animatedBack.SetActive(true);
            animatedFront.SetActive(false);
            dir = PlayerStats.Direction.Back;
        }
        else if (zDir < xDir)
        {
            // walk front
            animatedRight.SetActive(false);
            animatedLeft.SetActive(false);
            animatedBack.SetActive(false);
            animatedFront.SetActive(true);
            dir = PlayerStats.Direction.Front;
        }

        PlayerStats.SetFacing(dir);
    }
}
