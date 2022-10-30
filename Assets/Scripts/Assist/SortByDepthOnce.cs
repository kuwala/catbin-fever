using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortByDepthOnce : MonoBehaviour
{
    // Start is called before the first frame update
    int IsometrixRangePerYUnit = 16;
    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.sortingOrder = -(int)(transform.position.y * IsometrixRangePerYUnit);
        //order = renderer.sortingOrder;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
