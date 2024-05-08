using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornDamage : MonoBehaviour
{
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Thorn"))
        {
            Destroy(collision.gameObject);
            gameManager.AttackPlayer(3.0f);
        }
    }
}
