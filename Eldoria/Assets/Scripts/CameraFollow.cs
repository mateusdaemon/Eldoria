using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float zOffset = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Keep camera height
        this.transform.position = new Vector3(player.transform.position.x, 
            this.transform.position.y, player.transform.position.z - zOffset); 
    }
}
