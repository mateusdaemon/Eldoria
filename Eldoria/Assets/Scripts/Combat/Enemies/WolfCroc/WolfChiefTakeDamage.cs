using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfChiefTakeDamage : MonoBehaviour
{
    public ParticleSystem blood;

    private Enemy currEnemy;
    private GameManager gm;
    private WolfCrocState wolfState;
    private bool canDodge = true;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        currEnemy = GetComponent<Enemy>();
        wolfState = GetComponent<WolfCrocState>();
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

            if (!canDodge)
            {
                blood.transform.position = collision.collider.ClosestPoint(transform.position);
                blood.Play();

                currEnemy.TakeDamage(PlayerStats.GetDamage());
            } else
            {
                wolfState.SetWolfState(WolfCrocState.WolfState.Dodge);
                canDodge = false;
                Invoke("ResetDodge", 2.0f);
            }
        }
    }

    private void OnDestroy()
    {
        gm.sm.PlaySfx(gm.sm.sfxWolfDie);
    }

    private void ResetDodge()
    {
        canDodge = true;
    }
}
