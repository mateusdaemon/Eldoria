using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMovment : MonoBehaviour
{
    public float speedX = 0.1f;
    public float speedY = 0.1f;
    private float currX;
    private float currY;
    // Start is called before the first frame update
    void Start()
    {
        currX = GetComponent<Renderer>().material.mainTextureOffset.x;
        currY = GetComponent<Renderer>().material.mainTextureOffset.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

        currX += Time.deltaTime * speedX;
        currY += Time.deltaTime * speedY;

        GetComponent<Renderer>().material.SetTextureOffset("_Water", new Vector2(currX, currY));
    }
}
