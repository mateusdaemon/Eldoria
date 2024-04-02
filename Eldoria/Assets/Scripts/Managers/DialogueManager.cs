using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [Header("NPC")]
    public TextMeshProUGUI npcName;
    public Image npcImgUI;
    public TextMeshProUGUI npcText;

    [Header("Player")]
    public GameObject playerBtns;
    public TextMeshProUGUI ans1;
    public TextMeshProUGUI ans2;
    public GameObject btn2; // This vanishes when there is no ans2

    [Header("General")]
    public GameObject dialogueObjects;


    private List<DialNode> dialTree;
    private int treeIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDialTree(List<DialNode> dialNodes, string name, Sprite npcImg)
    {
        dialTree = dialNodes;
        npcName.text = name;
        npcImgUI.sprite = npcImg;
        npcText.text = dialTree[0].npcText;
        npcText.maxVisibleCharacters = 0;
        ans1.text = dialTree[0].ans1;
        ans2.text = dialTree[0].ans2;
        Invoke("RevealEffect", 0);

        playerBtns.SetActive(false);

        if (ans2.text.Length == 0)
        {
            btn2.SetActive(false);
        } else
        {
            btn2.SetActive(true);
        }

        treeIndex = 0;
    }

    public void PrintNextNode()
    {
        CancelInvoke();
        playerBtns.SetActive(false);

        if (dialTree[treeIndex].leafNode)
        {
            dialogueObjects.SetActive(false);
            return;
        }

        treeIndex++;
        npcText.text = dialTree[treeIndex].npcText;
        npcText.maxVisibleCharacters = 0;
        Invoke("RevealEffect", 0);
        ans1.text = dialTree[treeIndex].ans1;
        ans2.text = dialTree[treeIndex].ans2;

        if (ans2.text.Length == 0)
        {
            btn2.SetActive(false);
        }
        else
        {
            btn2.SetActive(true);
        }
    }

    private void RevealEffect()
    {
        if (npcText.maxVisibleCharacters != npcText.text.Length)
        {
            npcText.maxVisibleCharacters++;
            Invoke("RevealEffect", 0.05f);
        } else
        {
            playerBtns.SetActive(true);
        }
    }

    public void SkipRevealEffect()
    {
        CancelInvoke();
        npcText.maxVisibleCharacters = npcText.text.Length;
        playerBtns.SetActive(true);
    }
}
