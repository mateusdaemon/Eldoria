using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI manaLabel;
    public GameObject manaBar;
    private float manaMaxWidth;

    // Start is called before the first frame update
    void Start()
    {
        manaMaxWidth = manaBar.GetComponent<Image>().rectTransform.sizeDelta.x;
    }

    // Update is called once per frame
    void Update()
    {
        manaLabel.text = PlayerStats.GetMana() + "/10";

        float singleManaWidth = manaMaxWidth / PlayerStats.GetMaxMana();

        manaBar.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(PlayerStats.GetMana() * singleManaWidth, manaBar.GetComponent<Image>().rectTransform.sizeDelta.y);
    }
}
