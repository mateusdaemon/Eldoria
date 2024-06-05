using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSpawner : MonoBehaviour
{
    public GameObject plantGp1;
    public GameObject plantGp2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void SpawnGroup(int number)
    {
        switch(number)
        {
            case 1:
                plantGp1.SetActive(true);
                break;
            case 2:
                plantGp2.SetActive(true);
                break;
        }
    }
}
