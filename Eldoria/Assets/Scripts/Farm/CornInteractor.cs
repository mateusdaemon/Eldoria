using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornInteractor : MonoBehaviour
{
    public QuestManager qm;
    public GameObject cornInteractUI;
    public GameObject cornIconUI;
    public ParticleSystem cornParticle;

    private bool canCollect = false;
    private bool cornCollected = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canCollect && Input.GetKeyDown(KeyCode.F))
        {
            qm.CornContinue();
            qm.SetWagonInteract(true);
            cornIconUI.SetActive(false);
            cornInteractUI.SetActive(false);
            cornCollected = true;
            cornParticle.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (qm.GetCornActive() && !cornCollected)
            {
                cornInteractUI.SetActive(true);
                canCollect = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cornInteractUI.SetActive(false);
            canCollect = false;
        }
    }
}
