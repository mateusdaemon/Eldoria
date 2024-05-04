using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static WolfCrocState;

public class WolfTakeDamage : MonoBehaviour
{
    public ParticleSystem blood;

    private Enemy currEnemy;
    private GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        currEnemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Instantiate(collision.gameObject.GetComponent<Bullet>().effect, collision.gameObject.transform.position, new Quaternion());
            Destroy(collision.gameObject.gameObject);
           
            blood.transform.position = collision.collider.ClosestPoint(transform.position);
            blood.Play();

            currEnemy.TakeDamage(PlayerStats.GetDamage());
        }
    }

    private void OnDestroy()
    {
        gm.sm.PlaySfx(gm.sm.sfxWolfDie);
    }
}
