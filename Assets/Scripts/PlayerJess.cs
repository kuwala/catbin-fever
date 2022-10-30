using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJess : MonoBehaviour
{
    public float moveAcceleration = 10f;
    public Vector2 maxVelocity = new Vector2(10, 10);
    private Vector3 scale;
    private Animator animator;
    private PlayerController controller;
    public Transform garbagePosition;
    public List<Pickup> pickups;
    private int facingDir;
    public GameManager1 gameManger;

    public AudioClip catchSound;
    public AudioClip swareSound;

    private AudioSource audioSource;

    void Start()
    {
        scale = GetComponent<Transform>().localScale;
        controller = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
        pickups = new List<Pickup>();
        audioSource = GetComponent<AudioSource>();
       // facingDir = 0; // 0 right , 1 left

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

        if(controller.actionPressed)
        {
            audioSource.PlayOneShot(catchSound);
        }

        if (absVelX < 0.2f || absVelY < 0.2f)
        {
                /*if (animator.GetInteger("AnimState") == 3)
                {
                    animator.SetInteger("AnimState", 1);
                }
                else if (animator.GetInteger("AnimState") == 4)
                {
                    animator.SetInteger("AnimState", 0);
                }
                */
            }




        GetComponent<Rigidbody2D>().AddForce(new Vector2(forceX, forceY));

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //print(collision.transform.tag);
        if (collision.transform.tag == "Cat")
        {
            Cat cat = collision.transform.GetComponent<Cat>();
            if(cat.catchable == true)
            {
                if (controller.actionPressed)
                {
                   if (cat.AttemptCatch() == true)
                    {
                        gameManger.CaughtCat();
                        collision.gameObject.SetActive(false);
                    }
                    cat.catchable = false; // lock the cat out so that it can not be caught again on this collision
                }
                else
                {
                    // touched cat but not pressed
                    // play escape sound
                }

            }
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //print(collision.transform.tag);
        if (collision.transform.tag == "Cat")
        {
            Cat cat = collision.transform.GetComponent<Cat>();
            cat.catchable = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print(collision.transform.tag);
        if (collision.transform.tag == "Cat")
        {
            Cat cat = collision.transform.GetComponent<Cat>();
            if (controller.actionPressed)
            {
                // play catch attempt sound
                if (cat.AttemptCatch() == true)
                {
                    gameManger.CaughtCat();
                    collision.gameObject.SetActive(false);
                }
            }
            else
            {
                // touched cat but not pressed
                // play escape sound
            }

            /*
            Rigidbody2D _rb = collision.transform.GetComponent<Rigidbody2D>();
            //_rb.isKinematic = true;
            _rb.simulated = false;
            collision.transform.parent = transform;
            collision.transform.position = garbagePosition.transform.position;
            Pickup p = collision.gameObject.GetComponent<Pickup>();
            pickups.Add(p);
            */
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.transform.tag == "Home")
        {
            
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
