using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class OrchidBehavior : MonoBehaviour
{
    private GameManager gameManager;
    private OrchidState orchidState;
    private GameObject playerRef;
    private GameObject parent;
    private bool canAttack = true;
    private bool threatened = false;

    public GameObject dangerSign;
    public SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        parent = this.transform.parent.gameObject;
        orchidState = parent.GetComponent<OrchidState>();
        playerRef = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerRef.transform.position.x < transform.position.x)
        {
            sprite.flipX = true;
        } else
        {
            sprite.flipX = false;
        }
        // se move lentamente até o player quando ameaçado
        if (threatened && canAttack)
        {
            orchidState.ChangeState(OrchidState.PlantState.Attack);
            canAttack = false;
            Invoke("ResetCanAttack", 2.0f);
        } else
        {
            orchidState.ChangeState(OrchidState.PlantState.Idle);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        dangerSign.SetActive(true);
        threatened = true;
    }

    private void OnTriggerExit(Collider other)
    {
        threatened = false;
        dangerSign.SetActive(false);
    }

    private void ResetCanAttack()
    {
        canAttack = true;
    }
}
