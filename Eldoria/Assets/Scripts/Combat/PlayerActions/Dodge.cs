using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dodge : MonoBehaviour
{
    [Header("---Manager---")]
    public SoundManager sm;

    [Header("---Dodge---")]
    private Rigidbody rb;
    private float xDir, zDir;
    private bool canDodge = true;
    private float amount = 0;

    public GameManager gm;
    public float dodgeForce;
    public float coldown;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerStats.SkillEnable() || PlayerStats.IsDialoguing())
        {
            return;
        }

        if (!canDodge)
        {
            amount += 1.0f / coldown * Time.deltaTime;
            gm.hudManager.SetDodgeAmount(amount);
        }

        xDir = Input.GetAxis("Horizontal");
        zDir = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (PlayerStats.CanMove() && canDodge)
            {
                if (xDir == 0 && zDir == 0)
                {
                    // If there is no input, check which dir player is facing
                    SetDodgeDirection(ref xDir, ref zDir);
                }
                sm.PlaySfx(sm.sfxDodge);
                rb.AddForce(new Vector3(xDir, 0, zDir) * dodgeForce, ForceMode.Impulse);
                canDodge = false;
                gm.PlayerDodge();
                Invoke("EnableDodge", coldown);
            }
            else
            {
                sm.PlaySfx(sm.sfxDodgeErro);
                gm.CantDodgeFeedback();
                Invoke("RestoreDodgeFeedback", 0.15f);
            }
        }

    }

    private void EnableDodge()
    {
        canDodge = true;
        amount = 0;
        gm.EnableDodge();
    }

    private void RestoreDodgeFeedback()
    {
        gm.RestoreDodgeFeedback();
    }

    private void SetDodgeDirection(ref float xDir, ref float zDir)
    {
        xDir = 0; zDir = 0;
        switch (PlayerStats.FacingDir())
        {
            case PlayerStats.Direction.Right:
                xDir = -1;
                break;
            case PlayerStats.Direction.Left:
                xDir = 1;
                break;
            case PlayerStats.Direction.Front:
                zDir = 1;
                break;
            case PlayerStats.Direction.Back:
                zDir = -1;
                break;
            default:
                break;
        }
    }
}
