using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Playing,
    Loose,
    Win,
    Idle,
    Instruction
}
public class GameManager1 : MonoBehaviour
{
    public GameState gameState = GameState.Idle;
    public int catsCollected = 0;
    public int catsNeeded = 4;
    private int score = 0;
    public TMPro.TextMeshProUGUI timerText;
    public TMPro.TextMeshProUGUI catsText;

    private float timer = 30f;
    // 0 - not
    
    // Great its Game Manger 1 to the rescure here!
    void Start()
    {

        Time.timeScale = 0f;
        gameState = GameState.Instruction;
    }

    // Update is called once per frame
    void Update()
    {
        
                // decrement timer
        switch(gameState)
        {
            case GameState.Instruction:
                // show instructions
                if(Input.GetKey(KeyCode.Space))
                {
                    //hide instructions

                    ResetGame();
                    gameState = GameState.Playing;
                    print("Starting game");
                    Time.timeScale = 1f;

                }
                break;
            case GameState.Idle:
                break;
            case GameState.Playing:
                // if timer is zero check for win loose
                // decrement timer
                timer -= Time.deltaTime;
                timerText.text = "Timea left: " + Mathf.Round(timer);
                catsText.text = "Cats: " + catsCollected + "   Scorez: " + score;
                CheckWinLoose();

                break;
            case GameState.Win:
                // show winScreen
                break;
            case GameState.Loose:
                // show looseScreen
                break;
        }
        
    }
    public void CheckWinLoose()
    {
        if(timer <= 0)
        {
            if(catsCollected >= 4)
            {
                gameState = GameState.Win;

            }
            else
            {
                gameState = GameState.Loose;

            }
        }
    }
    public void ResetGame()
    {
        // show ui texts

        // reset scores and timers
        timer = 30f;
        catsCollected = 0;
        score = 0;

    }
    public void CaughtCat()
    {
        catsCollected += 1;
    }

    public void AddScore(int s)
    {
        score += s;
    }
}
