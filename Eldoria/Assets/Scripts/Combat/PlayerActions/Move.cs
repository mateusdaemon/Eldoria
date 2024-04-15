using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public GameManager gm;
    private Rigidbody rb;
    private float xDir, zDir;

    public float velocity;
    public GameObject animatedFront, animatedBack, animatedRight, animatedLeft;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!PlayerStats.CanMove() || PlayerStats.IsDialoguing())
        {
            return;
        }

        xDir = Input.GetAxis("Horizontal");
        zDir = Input.GetAxis("Vertical");

        if (xDir != 0 || zDir != 0)
        {
            float realVelocity = velocity;
            OrientPlayerSprite();
            if (Input.GetKey(KeyCode.LeftShift)) 
            {
                realVelocity *= 1.5f; 
            }

            rb.AddForce(new Vector3(xDir, 0, zDir) * realVelocity);
        } else
        {
            if (animatedFront.activeSelf) { animatedFront.GetComponent<Animator>().SetBool("walk", false); }
            if (animatedBack.activeSelf) { animatedBack.GetComponent<Animator>().SetBool("walk", false); }
            if (animatedRight.activeSelf) { animatedRight.GetComponent<Animator>().SetBool("walk", false); }
            if (animatedLeft.activeSelf) { animatedLeft.GetComponent<Animator>().SetBool("walk", false); }
        }
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
            animatedLeft.GetComponent<Animator>().SetBool("walk", true);
            dir = PlayerStats.Direction.Left;
        }
        else if (xDir > 0)
        {
            // walk right
            animatedLeft.SetActive(false);
            animatedRight.SetActive(true);
            animatedBack.SetActive(false);
            animatedFront.SetActive(false);
            animatedRight.GetComponent<Animator>().SetBool("walk", true);
            dir = PlayerStats.Direction.Right;
        }
        else if (zDir > xDir)
        {
            // walk back
            animatedRight.SetActive(false);
            animatedLeft.SetActive(false);
            animatedBack.SetActive(true);
            animatedFront.SetActive(false);
            animatedBack.GetComponent<Animator>().SetBool("walk", true);
            dir = PlayerStats.Direction.Back;
        }
        else if (zDir < xDir)
        {
            // walk front
            animatedRight.SetActive(false);
            animatedLeft.SetActive(false);
            animatedBack.SetActive(false);
            animatedFront.SetActive(true);
            animatedFront.GetComponent<Animator>().SetBool("walk", true);
            dir = PlayerStats.Direction.Front;
        }

        PlayerStats.SetFacing(dir);
    }
}
