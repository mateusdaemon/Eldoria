using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeYDir : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            this.gameObject.GetComponent<Rigidbody>().constraints = this.gameObject.GetComponent<Rigidbody>().constraints | RigidbodyConstraints.FreezePositionY;
        }
    }
}
