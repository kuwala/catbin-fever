using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    public float zoomValue = 2.0f;
    private Transform _t;
    // Start is called before the first frame update
    private void Awake()
    {
        //GetComponent<Camera>().orthographicSize = ((Screen.height / zoomValue / 32f));

    }
    void Start()
    {
        _t = target.transform;

    }

    // Update is called once per frame
    void Update()
    {
        //_t = target.transform;

        float _x = _t.position.x;
        float _y = _t.position.y;

        //if (_x < -6)
        //    _x = -6;

        //if (_x > 6)
        //    _x = 6;
        //if (_y < -3)
        //    _y = -3;
        //if (_y > 3)
            //_y = 3;
        //transform.position = new Vector3(_t.position.x, _t.position.y, transform.position.z);

        transform.position = new Vector3(_x,_y, transform.position.z);

    }
}

