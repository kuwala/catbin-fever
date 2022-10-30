using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandWalker : MonoBehaviour
{
    // Start is called before the first frame update
    float x;
    public int dir = 0;
    public int frameCounter = 0;
    public int moveRate = 30;
    Transform t;
    void Start()
    {
        t = transform;   
    }

    // Update is called once per frame
    void Update()
    {
        frameCounter+=1;

        if(frameCounter > moveRate)
        {
            //Vector3 pos = transform.position;
            //pos.x += 1;
            //transform.position = pos;

            frameCounter = 0;
            randMove();
        }
        
        
    }
    void randMove()
    {
        Vector3 pos = transform.position;

        float n = Random.Range(0f, 1f);
        if (n > 0.75f)
        {
            dir = 0;
            pos.x += 1;
        }
        else if (n > 0.5f)
        {
            dir = 1;
            pos.x -= 1;
        }
        else if (n > 0.25f)
        {
            dir = 2;
            pos.y = 1;
        }
        else
        {
            dir = 3;
            pos.y = -1;
        }
        transform.position = pos;
    }
}
