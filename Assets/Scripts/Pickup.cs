using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public float bobbleDistance = 0.2f;
    private float angle = 0.0f;
    public float changeRate = 0.01f;
    private float originalY = 0;
    // Start is called before the first frame update
    void Start()
    {
        originalY = transform.position.y;
        
    }

    // Update is called once per frame
    void Update()
    {
        angle += changeRate;
        if(angle > Mathf.PI)
        {
            angle -= Mathf.PI;
        }
        print(Mathf.Sin(angle));
        float yShift =  bobbleDistance * Mathf.Sin(angle);
        
        transform.position = new Vector3(transform.position.x, originalY + yShift, transform.position.z);
        
    }
}
