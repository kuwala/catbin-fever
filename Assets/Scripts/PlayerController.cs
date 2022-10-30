using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    public Vector2 moving = new Vector2();

    public int selectPlayer = 1; // 1, 2, 3, 4
    public bool actionPressed = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moving.x = moving.y = 0;
        //float value = Input.GetAxis("Horizontal1");


        if (selectPlayer == 1)
        {

            if (Input.GetKey("joystick 1 button 8"))
            {
                moving.x = 1;
            }
            else if (Input.GetKey("joystick 1 button 7"))
            {
                moving.x = -1;
            }

            if (Input.GetKey("joystick 1 button 5"))
            {
                moving.y = 1;
            }
            else if (Input.GetKey("joystick 1 button 6"))
            {
                moving.y = -1;
            }
        }
        else if (selectPlayer == 2)
        {

            if (Input.GetKey("d"))
            {
                moving.x = 1;
            }
            else if (Input.GetKey("a"))
            {
                moving.x = -1;
            }

            if (Input.GetKey("w"))
            {
                moving.y = 1;
            }
            else if (Input.GetKey("s"))
            {
                moving.y = -1;
            }
        }
        else if (selectPlayer == 3)
        {

            if (Input.GetKey("right"))
            {
                moving.x = 1;
            }
            else if (Input.GetKey("left"))
            {
                moving.x = -1;
            }

            if (Input.GetKey("up"))
            {
                moving.y = 1;
            }
            else if (Input.GetKey("down"))
            {
                moving.y = -1;
            }
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            actionPressed = true;
        }
        else
        {
            actionPressed = false;
        }


    } // end update


}

