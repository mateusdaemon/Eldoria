using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private Vector3 origin;
    private bool goToPlayer = false;
    private GameObject playerRef;
    private GameObject parent;
    private Vector3 moveTarget;
    private bool originSet = false;

    // Start is called before the first frame update
    void Start()
    {
        parent = this.transform.parent.gameObject;
        Invoke("SetOrigin", 1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (goToPlayer)
        {
            if (Vector3.Distance(parent.transform.position, playerRef.transform.position) > 1.5f)
            {
                moveTarget.x = playerRef.transform.position.x;
                moveTarget.z = playerRef.transform.position.z;
                parent.transform.position = Vector3.MoveTowards(parent.transform.position, moveTarget, 0.1f);
            }
        } else
        {
            if (originSet && parent.transform.position != origin)
            {
                parent.transform.position = Vector3.MoveTowards(parent.transform.position, origin, 0.1f);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        goToPlayer = true;
        playerRef = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        goToPlayer = false;
        playerRef = null;
    }

    private void SetOrigin()
    {
        origin = transform.position;
        moveTarget = new Vector3(0, origin.y, 0);
        originSet = true;
    }

}
