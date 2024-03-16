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
    public GameObject dodgeBgUI;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        xDir = Input.GetAxis("Horizontal");
        zDir = Input.GetAxis("Vertical");

        if (!canDodge)
        {
            dodgeBgUI.GetComponent<Image>().fillAmount += 1.0f / coldown * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && canDodge)
        {
            rb.AddForce(new Vector3(xDir, 0, zDir) * dodgeForce, ForceMode.Impulse);
            canDodge = false;
            dodgeBgUI.GetComponent<Image>().fillAmount = 0;
            Invoke("EnableDodge", coldown);
        }
    }

    private void EnableDodge()
    {
        canDodge = true;
        dodgeBgUI.GetComponent<Image>().fillAmount = 1;
    }
}
