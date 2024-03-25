using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WagonInteractor : MonoBehaviour
{
    public QuestManager qm;
    public GameObject wagonInteractUI;
    public GameObject wagonInteractor;
    public GameObject bagOfCorn;

    private bool canPlaceBag = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canPlaceBag && Input.GetKeyDown(KeyCode.F))
        {
            qm.CornLastContinue();
            qm.SetWagonInteract(false);
            qm.SetFinishCorn(true);
            wagonInteractor.SetActive(false);
            bagOfCorn.SetActive(true);
        }        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (qm.GetWagonInteract())
            {
                wagonInteractUI.SetActive(true);
                canPlaceBag = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (wagonInteractUI != null)
            {
                wagonInteractUI.SetActive(false);
                canPlaceBag = false;
            }
        }
    }
}
