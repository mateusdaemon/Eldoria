using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooter : MonoBehaviour
{
    public SpellbookMng spellbook;
    public Bullet redBullet;
    public Bullet greenBullet;
    public Bullet blueBullet;
    public Bullet neutralBullet;
    public LayerMask layerClick;
    public float shootColdown;
    public GameObject attackBgUI;
    public AudioSource shootSfx;

    private Camera cam;
    private bool canShoot = true;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerStats.CanShoot())
        {
            return;
        }

        Vector3 currTarget;
        Bullet currBullet = null;

        if (!canShoot)
        {
            attackBgUI.GetComponent<Image>().fillAmount += 1.0f / shootColdown * Time.deltaTime;
        }

        if (canShoot && Input.GetMouseButtonDown(0) && PlayerStats.GetMana() > 0)
        {
            Ray mouseRay = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(mouseRay, out RaycastHit hit, float.MaxValue))
            {
                currTarget = hit.point;
                currTarget.y = 0.2f; // all shots are in same height
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
                    currBullet = Instantiate(neutralBullet, this.transform.position, new Quaternion());
                    break;
                default:
                    break;
            }

            shootSfx.Play();

            currBullet.transform.Rotate(new Vector3(70, 100, 0));
            currBullet.SetTarget(currTarget);

            PlayerStats.DropMana(1);
            canShoot = false;

            attackBgUI.GetComponent<Image>().fillAmount = 0;
            Invoke("EnableShoot", shootColdown);
        }
    }

    private void EnableShoot()
    {
        canShoot = true;
        attackBgUI.GetComponent<Image>().fillAmount = 1;
    }
}
