using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float zOffset = 0;

    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 target = new Vector3(player.transform.position.x, this.transform.position.y, player.transform.position.z - zOffset);

        this.transform.position = Vector3.Lerp(this.transform.position, target, 0.3f);
    }
}
