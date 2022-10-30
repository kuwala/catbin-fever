using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
[RequireComponent(typeof(Renderer))]
public class SortByDepth : MonoBehaviour
{

    private const int IsometrixRangePerYUnit = 16;
    public float order = 0f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.sortingOrder = -(int)(transform.position.y * IsometrixRangePerYUnit);
        order = renderer.sortingOrder;

    }
}
