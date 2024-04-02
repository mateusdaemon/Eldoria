using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialNode
{
    public string npcText;
    public string ans1;
    public string ans2;
    public bool leafNode = false;

    public DialNode(string npcTxt, string ansr1, string ansr2)
    {
        this.npcText = npcTxt;
        this.ans1 = ansr1;
        this.ans2 = ansr2;
    }
}
