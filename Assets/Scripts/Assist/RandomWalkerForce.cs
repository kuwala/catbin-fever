using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWalkerForce : MonoBehaviour
{
    // Start is called before the first frame update
    float x;
    public int dir = 0;
    public int frameCounter = 0;
    public int moveRate = 30;
    private Rigidbody2D rb;
    public float thrust = 4.0f;
    Transform t;
    void Start()
    {
        t = transform;
    }

    // Update is called once per frame
    void Update()
    {
        frameCounter += 1;
        rb = GetComponent<Rigidbody2D>();

        if (frameCounter > moveRate)
        {
            //Vector3 pos = transform.position;
            //pos.x += 1;
            //transform.position = pos;

            frameCounter = 0;
            randMove(1f);
        }


    }
    public void randMove(float mult)
    {
        Vector3 pos = transform.position;
        Vector2 force = new Vector2(0, 0);
        
        // applies a force on the ridgidBody in a random X or random Y direction
        float n = Random.Range(0f, 1f);
        
        if (n > 0.75f)
        {
            dir = 0;
             force = new Vector2(thrust * mult, 0);
        }
        else if (n > 0.5f)
        {
            dir = 1;
            force = new Vector2(-1 * thrust * mult, 0);
        }
        else if (n > 0.25f)
        {
            dir = 2;
            force = new Vector2(0, thrust * mult);
        }
        else
        {
            dir = 3;
            force = new Vector2(0, -1 * thrust * mult);
        }

        rb.AddForce(force, ForceMode2D.Impulse);
        
        transform.position = pos;
    }
}
