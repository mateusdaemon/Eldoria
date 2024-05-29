using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private GameManager gm;
    private Rigidbody rb;
    private PlayerState playerState;
    private float xDir, zDir;

    public float velocity;
    
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody>();
        playerState = GetComponent<PlayerState>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!PlayerStats.CanMove() || PlayerStats.IsDialoguing())
        {
            if (PlayerStats.IsDialoguing())
            {
                playerState.ChangeState(State.Dialogue);
            }
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
                playerState.ChangeState(State.Run);
                gm.sm.walkSource.Stop();
                if (!gm.sm.runSource.isPlaying)
                {
                    gm.sm.PlayRun(gm.sm.sfxRun);
                }
            } else
            {
                Debug.Log("Walk state");
                playerState.ChangeState(State.Walk);
                gm.sm.runSource.Stop();
            }

            if (!gm.sm.walkSource.isPlaying)
            {
                gm.sm.PlayWalk(gm.sm.sfxWalk);
            }

            if (playerState.GetState() != State.Stuck)
            {
                rb.AddForce(new Vector3(xDir, 0, zDir) * realVelocity);
            }

        } else
        {
            playerState.ChangeState(State.Idle);
            gm.sm.walkSource.Stop();
        }
    }


    private void OrientPlayerSprite()
    {
        PlayerStats.Direction dir = PlayerStats.Direction.Front;

        if (xDir < 0)
        {
            dir = PlayerStats.Direction.Left;
        }
        else if (xDir > 0)
        {
            dir = PlayerStats.Direction.Right;
        }
        else if (zDir > xDir)
        {
            dir = PlayerStats.Direction.Back;
        }
        else if (zDir < xDir)
        {
            dir = PlayerStats.Direction.Front;
        }

        PlayerStats.SetFacing(dir);
    }
}
