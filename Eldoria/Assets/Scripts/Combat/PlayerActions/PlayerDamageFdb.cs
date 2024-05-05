using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageFdb : MonoBehaviour
{
    public ParticleSystem bloodFdb;

    public void DamageFeedback()
    {
        bloodFdb.Play();
    }
}
