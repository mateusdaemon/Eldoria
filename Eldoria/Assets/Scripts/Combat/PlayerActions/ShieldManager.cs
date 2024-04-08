using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldManager : MonoBehaviour
{
    [Header("---Manager---")]
    public GameManager gm;
    public SoundManager sm;
    public GameObject player;
    public float shieldColdown;

    private bool canShield = true;
    private float amount = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerStats.SkillEnable() || PlayerStats.IsDialoguing())
        {
            return;
        }

        if (!canShield)
        {
            amount += 1.0f / shieldColdown * Time.deltaTime;
            gm.hudManager.SetShieldAmount(amount);
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (canShield && PlayerStats.GetMana() >= gm.GetShieldCost())
            {
                sm.PlaySfx(sm.sfxShield);
                gm.PlayerUseShield();
                Invoke("ActivateShieldSkill", shieldColdown);
                canShield = false;
            } else
            {
                sm.PlaySfx(sm.sfxShieldErro);
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
}
