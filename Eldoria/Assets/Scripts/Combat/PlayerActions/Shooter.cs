using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooter : MonoBehaviour
{
    [Header("---Manager---")]
    public GameManager gm;
    public SoundManager sm;

    [Header("---Player---")]
    public SpellbookMng spellbook;
    public Bullet redBullet;
    public Bullet greenBullet;
    public Bullet blueBullet;
    public Bullet neutralBullet;
    public LayerMask layerClick;
    public float shootColdown;
    

    private Camera cam;
    private bool canShoot = true;
    private float amount = 0;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerStats.SkillEnable() || PlayerStats.IsDialoguing())
        {
            return;
        }

        if (!canShoot)
        {
            amount += 1.0f / shootColdown * Time.deltaTime;
            gm.hudManager.SetShootAmount(amount);
        }

        Vector3 currTarget;
        Bullet currBullet = null;

        if (Input.GetMouseButtonDown(0))
        {
            if (PlayerStats.CanShoot() && canShoot && PlayerStats.GetMana() > 0)
            {
                Ray mouseRay = cam.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(mouseRay, out RaycastHit hit, float.MaxValue, layerClick))
                {
                    currTarget = hit.point;
                    currTarget.y = 1.0f; // all shots are in same height
                }
                else
                {
                    currTarget = new Vector3(0, 0, 0);
                }

                switch (spellbook.currSpellbook)
                {
                    case SpellbookMng.Spellbook.Red:
                        currBullet = Instantiate(redBullet, this.transform.position, new Quaternion());
                        break;
                    case SpellbookMng.Spellbook.Green:
                        currBullet = Instantiate(greenBullet, this.transform.position, new Quaternion());
                        break;
                    case SpellbookMng.Spellbook.Blue:
                        currBullet = Instantiate(blueBullet, this.transform.position, new Quaternion());
                        break;
                    case SpellbookMng.Spellbook.None:
                        currBullet = Instantiate(neutralBullet, this.transform.position, neutralBullet.transform.rotation);
                        break;
                    default:
                        break;
                }

                gm.PlayerShoot();
                sm.PlaySfx(sm.sfxShooter);
                currBullet.SetTarget(currTarget);
                canShoot = false;
                Invoke("EnableShoot", shootColdown);
            } else
            {
                sm.PlaySfx(sm.sfxShooterErro);
                gm.CantShootFeedback();
                Invoke("RestoreShootFeedback", 0.15f);
            }
        }
    }

    private void EnableShoot()
    {
        canShoot = true;
        amount = 0;
        gm.EnableShoot();
    }

    private void RestoreShootFeedback()
    {
        gm.RestoreShootFeedback();
    }
}
