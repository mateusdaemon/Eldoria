using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageFdb : MonoBehaviour
{
    public GameManager gm;
    public ParticleSystem bloodFdb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamageFeedback()
    {
        bloodFdb.Play();
    }
}
