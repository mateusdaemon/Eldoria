using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestScript : MonoBehaviour
{
    public GameObject front;
    public GameObject back;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float Ydir = Input.GetAxis("Vertical");

        if(Ydir > 0 )
        {
            front.SetActive(false);
            back.SetActive(true);
        }
        else if ( Ydir < 0 )
        {
            front.SetActive(true);
            back.SetActive(false);
        }
        
    }
}
