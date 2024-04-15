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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Instantiate(other.GetComponent<Bullet>().effect, other.transform.position, new Quaternion());
            Destroy(other.gameObject);

            blood.transform.position = other.ClosestPoint(transform.position);
            blood.Play();

            currEnemy.TakeDamage(PlayerStats.GetDamage());
        }
    }

    private void OnDestroy()
    {
        sm.PlaySfx(sm.sfxWolfDie);
    }
}
