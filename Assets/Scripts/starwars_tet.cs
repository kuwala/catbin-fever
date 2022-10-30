using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starwars_tet : MonoBehaviour
{
    Transform t;    // Start is called before the first frame update
    public float stopAt = 0;
    void Start()
    {
        t = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(t.position.y <= stopAt)
        {
            t.position = new Vector3(t.position.x, t.position.y + 0.01f, t.position.z);
        }
    }
}
