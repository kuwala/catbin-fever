using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedRemove : MonoBehaviour
{
    public float stayTime = 3f;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        stayTime -= Time.deltaTime;
        if (stayTime <= 0.0f)
        {
            RemoveSelf();
        }
    }
    public void RemoveSelf()
    {
        gameObject.SetActive(false);
    }
}
