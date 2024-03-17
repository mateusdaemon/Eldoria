using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepHerding : MonoBehaviour
{
    private GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            float dist = Vector3.Distance(this.transform.position, other.gameObject.transform.position);
            float posX = transform.position.x;
            float posZ = transform.position.z;
            Vector3 playerPos = other.transform.position;
            Vector3 sheepPos = this.transform.position;

            if (playerPos.x > sheepPos.x && playerPos.z > sheepPos.z)
            {
                posX -= dist;
                posZ -= dist;
            } else if (playerPos.x > sheepPos.x && playerPos.z < sheepPos.z)
            {
                posX -= dist;
                posZ += dist;
            } else if (playerPos.x < sheepPos.x && playerPos.z > sheepPos.z)
            {
                posX += dist;
                posZ -= dist;
            } else if (playerPos.x < sheepPos.x && playerPos.z < sheepPos.z)
            {
                posX += dist;
                posZ += dist;
            }

            Vector3 target = new Vector3(posX, 0, posZ);

            
            parent.transform.position = Vector3.MoveTowards(transform.position, target, 0.5f);
        }
    }
}
