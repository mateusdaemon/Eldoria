using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 target;
    public ParticleSystem effect;
    private Vector3 firstPos;

    // Start is called before the first frame update
    void Start()
    {
        firstPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveToTarget();
    }

    public void SetTarget(Vector3 click)
    {
        target = click;
    }

    public void MoveToTarget()
    {
        if (transform.position != target && Vector3.Distance(firstPos, transform.position) <= 12.0f)
        {
            this.transform.position = Vector3.MoveTowards(transform.position, this.target, 0.5f);
        }
        else
        {
            ParticleSystem currEff = Instantiate(effect, this.transform.position, new Quaternion());
            Destroy(this.gameObject);
        }
    }
}
