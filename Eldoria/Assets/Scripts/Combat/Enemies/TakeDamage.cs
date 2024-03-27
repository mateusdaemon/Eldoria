using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeDamage : MonoBehaviour
{
    public SoundManager sm;
    private Enemy currEnemy;
    public GameObject lifeBarUI;

    private float maxLife;
    // Start is called before the first frame update
    void Start()
    {
        currEnemy = GetComponent<Enemy>();
        maxLife = currEnemy.life;
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

            currEnemy.life -= (int)PlayerStats.GetDamage();
            sm.PlaySfx(sm.sfxWolfDie);
            lifeBarUI.GetComponent<Image>().fillAmount = currEnemy.life / maxLife;
        }
    }
}
