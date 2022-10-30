using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enter_Door : MonoBehaviour
{
    public string sceneName = "Tushy Island";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        print("jess is amazing");
        if (other.gameObject.tag == "Player")
        {
            //int y = SceneManager.GetActiveScene().buildIndex;
            //SceneManager.LoadScene(y + 1);
            //Hello I am danile here
            print("test");
            SceneManager.LoadScene(sceneName);
        }
    }
}
