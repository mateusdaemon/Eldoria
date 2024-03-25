using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WagonInteractor : MonoBehaviour
{
    public QuestManager qm;
    public GameObject wagonInteractUI;

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
            wagonInteractUI.SetActive(false);
            canPlaceBag = false;
        }
    }
}
