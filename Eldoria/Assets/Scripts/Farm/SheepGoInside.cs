using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepGoInside : MonoBehaviour
{
    public GameObject point1;
    public GameObject point2;
    public GameObject area;
    public QuestSheep questRef;

    private Vector3 pos1, pos2, fitPos;
    private float xBoundArea, zBoundArea;
    private bool goPos1 = false, goPos2 = false, fitArea = false;
    private Animator anim;
    private SpriteRenderer sr;
    private bool sheepCounted = false;

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

        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position != pos1 && goPos1 == true)
        {
            pos1.y = transform.position.y;
            anim.SetBool("frontWalk", false);
            anim.SetBool("backWalk", true);
            anim.SetBool("sideWalk", false);
            transform.position = Vector3.MoveTowards(transform.position, pos1, 0.1f);
        } else if (goPos1)
        {
            goPos1 = false;
            goPos2 = true;
        }

        if (transform.position != pos2 && goPos2 == true)
        {
            pos2.y = transform.position.y;
            anim.SetBool("frontWalk", false);
            anim.SetBool("backWalk", false);
            anim.SetBool("sideWalk", true);
            sr.flipX = true;
            transform.position = Vector3.MoveTowards(transform.position, pos2, 0.1f);
        }
        else if (goPos2)
        {            
            goPos2 = false;
            fitArea = true;
        }

        if (transform.position != fitPos && fitArea == true)
        {
            fitPos.y = transform.position.y;
            transform.position = Vector3.MoveTowards(transform.position, fitPos, 0.1f);
        } else if (fitArea == true)
        {
            fitArea = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SheepTrigger") && !sheepCounted)
        {
            goPos1 = true;
        }
    }
}
