using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfCrocDodge : MonoBehaviour
{
    private Rigidbody rb;
    private GameObject playerRef;

    public float dodgeForce = 10;
    public WolfCrocState wolfState;
    public WolfCrocBehavior wolfBehavior;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInParent<Rigidbody>();        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        playerRef = wolfBehavior.GetPlayerRef();

        if (playerRef != null && other.gameObject.CompareTag("Bullet"))
        {
            // If player is to close the wolf only cares about getting some meat
            if (Vector3.Distance(transform.position, playerRef.transform.position) > 2.0f)
            {
                Vector3 dodgeDir = new Vector3(0, 0, 0);

                if (Mathf.Abs(dodgeDir.x - transform.position.x) > 2.0f)
                {
                    if (other.gameObject.transform.position.x > transform.position.x)
                    {
                        dodgeDir.x = -1;
                    } else
                    {
                        dodgeDir.x = 1;
                    }
                } else
                {
                    if (other.gameObject.transform.position.z > transform.position.z)
                    {
                        dodgeDir.z = -1;
                    }
                    else
                    {
                        dodgeDir.z = 1;
                    }
                }

                wolfState.SetWolfState(WolfCrocState.WolfState.Dodge);
                rb.AddForce(dodgeDir * dodgeForce, ForceMode.Impulse);
            }
        }
    }
}
