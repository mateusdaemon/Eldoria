using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject objectToFollow;

    [SerializeField]
    private float standardZOffset = 12;
    [SerializeField]
    private float maxHeight = 15;
    [SerializeField]
    private float minHeight = 8;


    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Camera zoom by scroll
        float mouseScroll = Input.mouseScrollDelta.y;

        if (transform.position.y == maxHeight)
        {
            // When at the max heigh can only zoom in
            if (mouseScroll > 0)
            {
                float targetY = transform.position.y - 1;
                Vector3 heightPosition = new Vector3(transform.position.x, targetY, transform.position.z);
                this.transform.position = Vector3.Lerp(this.transform.position, heightPosition, 0.1f);
            }

        } else if (transform.position.y < maxHeight)
        {            
            if (mouseScroll > 0)
            {
                float targetY = 0;
                if (transform.position.y - 1.0f <= minHeight)
                {
                    targetY = minHeight;
                }
                else
                {
                    targetY = transform.position.y - 0.4f;
                }

                Vector3 heightPosition = new Vector3(transform.position.x, targetY, transform.position.z);
                transform.position = heightPosition;

            } else if (mouseScroll < 0)
            {
                float targetY = 0;
                if (transform.position.y + 1.0f >= maxHeight)
                {
                    targetY = maxHeight;
                } else
                {
                    targetY = transform.position.y + 0.4f;
                }

                Vector3 heightPosition = new Vector3(transform.position.x, targetY, transform.position.z);
                transform.position = heightPosition;
            }
        }

        // Z offset is calculated based on camera height
        float zOffset = transform.position.y * standardZOffset / maxHeight;

        Vector3 target = new Vector3(objectToFollow.transform.position.x, this.transform.position.y, objectToFollow.transform.position.z - zOffset);
        this.transform.position = Vector3.Lerp(this.transform.position, target, 0.3f);
    }
}
