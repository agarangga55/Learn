using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int playerHealth = 3;
    // Start is called before the first frame update
    void Start()
    {
        
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

    public void GameOver()
    {
        if (playerHealth <= 0)
        {
            Time.timeScale = 0f;
            Debug.Log("Player Lose");
        }
    }
}
