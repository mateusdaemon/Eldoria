using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public string npcName;
    public Sprite npcPic;
    [TextArea(4, 10)]
    public string[] npcTexts;
    [TextArea(4, 10)]
    public string[] playerAnswrs;
    
    private List<DialNode> dialTree;
    private int listIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        dialTree = new List<DialNode>();
        foreach (string npcTxt in npcTexts) 
        {
            // There are two answers for each text
            int indexAns1 = listIndex * 2;
            int indexAns2 = indexAns1 + 1;

            DialNode dialNode = new DialNode(npcTxt, playerAnswrs[indexAns1], playerAnswrs[indexAns2]);
            dialTree.Add(dialNode);
            listIndex++;
        }

        // Set last node as leaf node
        dialTree[listIndex - 1].leafNode = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<DialNode> GetDialTree()
    {
        return dialTree;
    }
}
