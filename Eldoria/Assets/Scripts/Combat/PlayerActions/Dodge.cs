using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dodge : MonoBehaviour
{
    private Rigidbody rb;
    private float xDir, zDir;
    private bool canDodge = true;

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
        if (!PlayerStats.CanMove())
        {
            return;
        }

        xDir = Input.GetAxis("Horizontal");
        zDir = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && canDodge)
        {
            rb.AddForce(new Vector3(xDir, 0, zDir) * dodgeForce, ForceMode.Impulse);
            canDodge = false;
            Invoke("EnableDodge", coldown);
        }
    }

    private void EnableDodge()
    {
        canDodge = true;
    }
}
