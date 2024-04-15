using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepGoInside : MonoBehaviour
{
    public GameObject point1;
    public GameObject point2;
    public GameObject area;
    public SheepGraze grazingBehavior;

    private SheepState sheepState;
    private Vector3 pos1, pos2, fitPos;
    private float xBoundArea, zBoundArea;
    private bool goPos1 = false, goPos2 = false, fitArea = false;

    // Start is called before the first frame update
    void Start()
    {
        pos1 = point1.transform.position;
        pos2 = point2.transform.position;
        
        xBoundArea = area.GetComponent<Collider>().bounds.size.x / 2;
        zBoundArea = area.GetComponent<Collider>().bounds.size.z / 2;
        
        fitPos = area.transform.position;
        fitPos.x += Random.Range(-xBoundArea, xBoundArea);
        fitPos.z += Random.Range(-zBoundArea, zBoundArea);

        sheepState = GetComponent<SheepState>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, pos1) >= 1.0f  && goPos1 == true)
        {
            pos1.y = transform.position.y;
            sheepState.SetSheepState(SheepState.ShipState.GoBack);
            transform.position = Vector3.MoveTowards(transform.position, pos1, 0.1f);
        } else if (goPos1)
        {
            goPos1 = false;
            goPos2 = true;
        }

        if (Vector3.Distance(transform.position, pos2) >= 1.0f && goPos2 == true)
        {
            pos2.y = transform.position.y;
            sheepState.SetSheepState(SheepState.ShipState.GoRight);
            transform.position = Vector3.MoveTowards(transform.position, pos2, 0.1f);
        }
        else if (goPos2)
        {            
            goPos2 = false;
            fitArea = true;
        }

        if (Vector3.Distance(transform.position, fitPos) >= 1.0f && fitArea == true)
        {
            fitPos.y = transform.position.y;
            transform.position = Vector3.MoveTowards(transform.position, fitPos, 0.1f);
        } else if (fitArea == true)
        {
            sheepState.SetSheepState(SheepState.ShipState.Idle);
            fitArea = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SheepTrigger"))
        {
            grazingBehavior.Graze(false);
            goPos1 = true;
        }
    }
}
