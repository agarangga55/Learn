using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int playerHealth = 3;
    public int playerScore;
    // Start is called before the first frame update
    void Start()
    {
        playerScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GameOver();
    }

    public void ReduceHealth()
    {
        playerHealth -= 1;
    }

    public void InstantLose()
    {
        playerHealth = 0;
    }

    public void GameOver()
    {
        if (playerHealth <= 0)
        {
            Time.timeScale = 0f;
            Debug.Log("Player Lose");
        }
    }

    public void AddScore()
    {
        playerScore += 1;
        Debug.Log("Player Score + 1 , Player Score = " + playerScore);
    }
}
