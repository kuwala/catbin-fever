using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    public Pickup pickup;
    public float spawnRate = 0.995f;
    public int startCount = 100;
    //private int count;
    // Start is called before the first frame update
    void Start()
    {
      //  count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //if(count < startCount)
        //{
            
        //    float targetValue = ExtensionMethods.Map((float)count, 0f, 100f, 0.6f, 0.995f);
        //    if (Random.value > targetValue)
        //    {
        //        Spawn();
        //        count++;
        //    }

        //}
        if (Random.value > spawnRate)
        {
            Spawn();
        }
    }
    public void Spawn()
    {
        Pickup clone = Instantiate(pickup, transform.position, Quaternion.identity) as Pickup;
        clone.GetComponent<Rigidbody2D>().AddForce(new Vector2(6,0));

    }
}
