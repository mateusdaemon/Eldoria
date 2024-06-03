using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordSpecific : MonoBehaviour
{
    public GameObject hordEnemy;
    public int quantity;

    public void SpawnCurrent()
    {
        quantity--;
    }
}
