using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
/* programing goals for 2/10/19 1:30am
 * Depleting Night Timer
 * Depleteing Food Resource
 * Increasing Day
 * Create Raccons with more Days
 * 
 * Miner To-dos:
 * --show full float above raccon when its full and tries to pick up
 * --throw/drop garbage
 * --pull garbage bag
 * --bag button trigger rotation
 */
 /* Todos for TONIIIGHT 
  * spawn more raccoons every 10 food
  * ? ? ? after day timer runs out open door ?
  * 
  */

public class GameManager : MonoBehaviour
{
    public float gameTime = 0.1f;
    public float foodResource = 10f;
    public float foodDepletionRate = 0.1f; // per ticTime
    public int gameDay = 1;
    public int dayOfTheWeek = 1; // 1-7 monday - sunday
    public float nightTimer = 0f; // 30 sec nights
    public float nightLength = 120f;
    public float raccoonSpawnTimer = 0f;
    public float raccoonSpawnTime = 120f;
    public float[] raccoonFoodCost;
    public GameObject raccoon;
    public Text garbageCount;
    public int garbageNum = 0;


    public int gameState = 0; // i dunno, play, pause, gameover kind of stuff??
    public int adultRaccons = 2;
    public int maxRaccoons = 6; // not sure if used

    // > - s-t-u-f-f -- s-t-u-f-f --- S.S.T.T.U.U.F.F.F.F ---- s-t-u-f-f -----
    // ticTIME 
    public float ticTime = 0.1f; // 1/10 of a second
    public float ticTimer = 0f;
    public int tics = 0;

    public GameObject progressBar;


    // 10 millis tic Timer 
    // lets just stick to counting
    // frames lol ... <---
    //                             ------->   ------->
    // f   o   r   m    a    t   i   o   n    s
    //

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // checking timers / resources for change state
        nightTimer += Time.deltaTime;
        ticTimer += Time.deltaTime;

        if (nightTimer >= nightLength)// new day
        {
            // reset player Position to start.
            // reset garbageSpawner
            // MoveAheadDay();
            MakeRaccon();
            print("Day Over");
            gameDay += 1;
            nightTimer = 0;

        }
        if (foodResource <= 0)
        {
            // starved .. gameOver? 
            // zombie mode 
            print("food over");
            foodResource = 11f; 
        }
        //deplete resources
        if (ticTimer >= ticTime)
        {
            ticTimer -= ticTime;
            foodResource -= foodDepletionRate;
            tics += 1;

        }

        float width = 0f;
        width = 1.1f; // nightTimer.Map( 0f, nightLength, 0f, 1.1f);
        progressBar.transform.localScale = new Vector3(width,0.09f,1f);
        garbageCount.text = garbageNum.ToString();
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
    public void MakeRaccon()
    {
        //Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;
        //Instantiate(prefab, pos, Quaternion.identity);

        Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Instantiate(raccoon, pos, Quaternion.identity);
    }

    public void IncreaseFoodBy(float by)
    {
        foodResource += by;
    }
    public void IncreaseGarbageBy(int num)
    {
        garbageNum += num;
    }

    public void GameOver()
    {

    }

}
enum MyEnum
{

}