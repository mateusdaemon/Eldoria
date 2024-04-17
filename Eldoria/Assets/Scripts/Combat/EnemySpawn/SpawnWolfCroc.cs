using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWolfCroc : MonoBehaviour
{
    public float coldown;
    public GameObject wolfPrefab;

    private float xBoundArea, zBoundArea;
    private Collider area;


    // Start is called before the first frame update
    void Start()
    {
        area = GetComponent<Collider>();
        xBoundArea = area.GetComponent<Collider>().bounds.size.x / 2;
        zBoundArea = area.GetComponent<Collider>().bounds.size.z / 2;
        InvokeRepeating("SpawnWolfPrefab", 0, coldown);
    }

    // Update is called once per frame
    void Update()
    {
                        
    }

    private void SpawnWolfPrefab ()
    {
        float xPos = Random.Range(-xBoundArea, xBoundArea);
        float zPos = Random.Range(-zBoundArea, zBoundArea);

        Instantiate(wolfPrefab, new Vector3(xPos, 1.5f, zPos), wolfPrefab.transform.rotation);
    }
}
