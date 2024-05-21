using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TransitionTexts : MonoBehaviour
{
    public TextMeshProUGUI[] texts;
    public GameObject continueBtn;
    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        foreach(TextMeshProUGUI text in texts)
        {
            text.maxVisibleCharacters = 0;
        }

        InvokeRepeating("ReavealText", 0.5f, 0.04f);

    }

    // Update is called once per frame
    void Update()
    {

        
    }

    private void ReavealText()
    {
        if (texts[index].maxVisibleCharacters != texts[index].text.Length)
        {
            texts[index].maxVisibleCharacters++;
        }
        else
        {
            if (index < texts.Length - 1)
            {
                index++;
            } else
            {
                CancelInvoke("ReavealText");
                continueBtn.SetActive(true);
            }
        }
    }
}
