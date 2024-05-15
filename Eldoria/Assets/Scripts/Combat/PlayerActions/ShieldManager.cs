using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldManager : MonoBehaviour
{
    [Header("---Manager---")]
    public GameObject player;
    public ParticleSystem shieldFdb;
    public ParticleSystem shieldBreak;
    public GameObject shieldAura;
    public float shieldColdown;

    private GameManager gm;
    private bool canShield = true;
    private float amount = 0;
    private bool shouldColdown = false;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerStats.SkillEnable() || PlayerStats.IsDialoguing())
        {
            return;
        }

        if (!canShield && shouldColdown)
        {
            amount += 1.0f / shieldColdown * Time.deltaTime;
            gm.hudManager.SetShieldAmount(amount);
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (canShield && PlayerStats.GetMana() >= gm.GetShieldCost())
            {
                gm.sm.PlaySfx(gm.sm.sfxShield);
                gm.PlayerUseShield();
                shieldFdb.Play();
                shieldAura.SetActive(true);
                canShield = false;
                shouldColdown = false;
            } else
            {
                gm.sm.PlaySfx(gm.sm.sfxShieldErro);
                gm.CantShieldFeedback();
                Invoke("RestoreShieldFeedback", 0.15f);
            }
        }
    }

    private void RestoreShieldFeedback()
    {
        gm.RestoreShieldFeedback();
    }

    private void ActivateShieldSkill()
    {
        gm.EnableShield();
        amount = 0;
        canShield = true;
    }

    public void DestroyShield()
    {
        shieldAura.SetActive(false);
        shieldBreak.Play();
        Invoke("ActivateShieldSkill", shieldColdown);
        shouldColdown = true;
    }
}
