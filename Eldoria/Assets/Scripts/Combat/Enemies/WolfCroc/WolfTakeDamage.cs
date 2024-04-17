using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WolfTakeDamage : MonoBehaviour
{
    public SoundManager sm;
    public GameObject lifeBarUI;
    public ParticleSystem blood;

    private Enemy currEnemy;
    // Start is called before the first frame update
    void Start()
    {
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
        sm.PlaySfx(sm.sfxWolfDie);
    }
}
