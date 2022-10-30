using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    // Start is called before the first frame update
    public int stamina = 4;
    public AudioClip meowSound;
    public AudioClip caughtSound;
    //public AudioClip escapeSound;
    AudioSource audioSource;
    public bool catchable = true; // gets locked on first frame of collion of triggerStay, then unlocked on triggerExit

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    public bool AttemptCatch()
    {
        stamina -= 1;
        if (stamina < 1)
        {
            
            print("caught cat");
            audioSource.PlayOneShot(caughtSound);
            return true;
        } 
        Boost(); // cat is not tired and tries to escape
        // play catch attempt sounds
        audioSource.PlayOneShot(meowSound);
        return false;
    }

    private void Boost()
    {
        RandomWalkerForce rf = GetComponent<RandomWalkerForce>();

        rf.randMove(4f);
    }
}
