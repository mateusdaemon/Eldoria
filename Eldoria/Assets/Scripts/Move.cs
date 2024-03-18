using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody rb;
    private float xDir, zDir;
    private Animator anim;
    private SpriteRenderer sr;

    public float velocity;
    public GameObject playerSpriteObj;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        anim = playerSpriteObj.GetComponent<Animator>();
        sr = playerSpriteObj.GetComponent<SpriteRenderer>();
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

        if (xDir == 0 && zDir == 0)
        {
            anim.SetBool("frontWalk", false);
            anim.SetBool("backWalk", false);
            anim.SetBool("sideWalk", false);
        }
        else
        {
            OrientPlayerSprite();
        }

        //rb.velocity = new Vector3(xDir, 0, zDir) * velocity;
        rb.AddForce(new Vector3(xDir, 0, zDir) * velocity);
    }


    private void OrientPlayerSprite()
    {
        if (xDir < 0)
        {
            // walk left
            sr.flipX = true;
            anim.SetBool("sideWalk", true);

            anim.SetBool("frontWalk", false);
            anim.SetBool("backWalk", false);
        }
        else if (xDir > 0)
        {
            // walk right
            sr.flipX = false;
            anim.SetBool("sideWalk", true);

            anim.SetBool("frontWalk", false);
            anim.SetBool("backWalk", false);
        }
        else if (zDir > xDir)
        {
            // walk back
            anim.SetBool("backWalk", true);

            anim.SetBool("sideWalk", false);
            anim.SetBool("frontWalk", false);
        }
        else if (zDir < xDir)
        {
            // walk front
            anim.SetBool("frontWalk", true);

            anim.SetBool("backWalk", false);
            anim.SetBool("sideWalk", false);
        }
    }
}
