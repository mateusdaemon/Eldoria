using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PrintChars : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject continueBtn;

    // Start is called before the first frame update
    void Start()
    {
        text.maxVisibleCharacters = 0;
        InvokeRepeating("ReavealText", 0.5f, 0.04f);
    }

    private void ReavealText()
    {
        if (text.maxVisibleCharacters != text.text.Length)
        {
            text.maxVisibleCharacters++;
        } else
        {
            CancelInvoke("ReavealText");
            continueBtn.SetActive(true);
        }
    }
}
