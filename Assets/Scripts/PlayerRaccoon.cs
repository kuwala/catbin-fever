using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaccoon : MonoBehaviour
{
    public float moveAcceleration = 10f;
    public Vector2 maxVelocity = new Vector2(10, 10);
    private Vector3 scale;
    private Animator animator;
    private PlayerController controller;
    public Transform garbagePosition;
    public List<Pickup> pickups;
    private int facingDir;
    public GameManager gameManger;

    void Start()
    {
        scale = GetComponent<Transform>().localScale;
        controller = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
        pickups = new List<Pickup>();
        facingDir = 0; // 0 right , 1 left

    }

    // Update is called once per frame
    void Update()
    {
        var forceX = 0f;
        var forceY = 0f;
        var absVelX = Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x);
        var absVelY = Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y);


        if (controller.moving.x != 0) {
            if (absVelX < maxVelocity.x)
            {
                forceX = moveAcceleration * controller.moving.x;
                //float sx = transform.localScale.x;
                //float sy = transform.localScale.y;
                //float sz = transform.localScale.z;
                //if (forceX < 0) { }
                //if (sx > 0)
                //    sx = sx * -1;
                //}
                //else
                //{
                //    if (sx < 0)
                //        sx = sx * -1;
                //}

                    
                
                transform.localScale = new Vector3(forceX < 0 ? -1 * scale.x : 1 * scale.x, scale.y, scale.z);

                if (forceX > 0)
                {
                    facingDir = 0;
                }
                else
                {
                    facingDir = 1;
                }

            }
        }


        if (controller.moving.y != 0)
        {
            if(absVelY < maxVelocity.y)
            {
                forceY = moveAcceleration * controller.moving.y;
            }

            if (forceX > 0)
            {
                facingDir = 3;
            }
            else
            {
                facingDir = 1;
            }
        }
        if (controller.moving.y > 0) // set move animation
        {

            //animator.SetInteger("AnimState", 3);
            facingDir = 1;
            //print("waling state 3");


        }
        else if (controller.moving.y < 0)
        {
            //animator.SetInteger("AnimState", 4);
            facingDir = 0;
            //print("waling state 4");


        }

        if (absVelX < 0.2f || absVelY < 0.2f)
        {/*
                if (animator.GetInteger("AnimState") == 3)
                {
                    animator.SetInteger("AnimState", 1);
                }
                else if (animator.GetInteger("AnimState") == 4)
                {
                    animator.SetInteger("AnimState", 0);
                } */
            }




        GetComponent<Rigidbody2D>().AddForce(new Vector2(forceX, forceY));

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //print(collision.transform.tag);
        if(collision.transform.tag == "Trash")
        {
            Rigidbody2D _rb = collision.transform.GetComponent<Rigidbody2D>();
            //_rb.isKinematic = true;
            _rb.simulated = false;
            collision.transform.parent = transform;
            collision.transform.position = garbagePosition.transform.position;
            Pickup p = collision.gameObject.GetComponent<Pickup>();
            pickups.Add(p);
        }

        if (collision.transform.tag == "Home")
        {
            //print("entered home");
            // remove trash
            // spawm more
            int numPickups = 0;
            foreach (Pickup p in pickups)
            {
                numPickups += 1;
                p.gameObject.transform.parent = null;
                p.gameObject.GetComponent<Rigidbody2D>().simulated = true;
                p.gameObject.transform.tag = "Home";
                p.gameObject.transform.tag = "HomeTrash";
            }
            pickups.Clear();
            gameManger.IncreaseGarbageBy(numPickups);

        }
        if (collision.transform.tag == "HomeTrash")
        {
            var velX = (GetComponent<Rigidbody2D>().velocity.x);
            var velY = (GetComponent<Rigidbody2D>().velocity.y);

            if (controller.actionPressed)
            {
                //collision.otherRigidbody.AddForce(new Vector2(3,3));
                collision.gameObject.SetActive(false);
            }
            print("home trash action!");
        }

    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    print("trigger home entered");
    //    if(other.transform.tag == "Home")
    //    {
    //        //print("entered home");
    //        // remove trash
    //        // spawm more
    //        foreach(Pickup p in pickups)
    //        {
    //            p.gameObject.transform.parent = null;
    //            print(p);
    //        }
    //        pickups.Clear();
    //    }
    //}
}
