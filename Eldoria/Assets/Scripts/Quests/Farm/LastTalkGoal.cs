using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastTalkGoal : MonoBehaviour
{
    public Quest questRelated;
    public Goal goal;
    private GameManager gameManager;
    public GameObject interact;
    private bool canInteract;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.F))
        {
            gameManager.LoadScene("FarmTransitionFinal");
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            interact.SetActive(true);
            canInteract = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            interact.SetActive(false);
            canInteract = false;
        }
    }
}
