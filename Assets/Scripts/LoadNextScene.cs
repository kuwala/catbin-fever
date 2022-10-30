using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class LoadNextScene : MonoBehaviour
{
    // Start is called before the first frame update
    public string levelName ="Tushy Island";
    public Boolean clickOrPressToContinue = false;
    public Boolean waitForDelay = false;
    private Boolean delayTriggered = false;
    public float delayTime = 4f;
    public float delayTimeTillLoad = 8f;
    void Start()
    {
        StartCoroutine(WaitCoroutine());
        StartCoroutine(LoadWaitCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        if(waitForDelay)
        {
            if(delayTriggered)
            {
                if (clickOrPressToContinue)
                {
                    if (Input.GetMouseButtonDown(0) || Input.GetButtonDown("Fire1"))
                    {
                        SceneManager.LoadScene(levelName); //Load scene called Game
                    }
                }
                else
                {
                    SceneManager.LoadScene(levelName);
                }
            }
           
        }else {
            if (clickOrPressToContinue)
            {
                if (Input.GetMouseButtonDown(0)|| Input.GetButtonDown("Fire1"))
                {
                    SceneManager.LoadScene(levelName); //Load scene called Game
                }
            }
        }
        
        
    }

    IEnumerator WaitCoroutine()
    {
        Debug.Log("started restart wait");
        yield return new WaitForSeconds(delayTime);
        delayTriggered = true;
        

    }
    IEnumerator LoadWaitCoroutine()
    {
        yield return new WaitForSeconds(delayTimeTillLoad);
        SceneManager.LoadScene(levelName); //Load scene called Game

    }
}
