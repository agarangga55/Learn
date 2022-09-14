using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameplayController : MonoBehaviour
{
    [SerializeField]
    private PlayerController pController;

    [SerializeField]
    private WaveSpawner waveController;
    [SerializeField]
    private TextMeshProUGUI lifeRemain;
    [SerializeField]
    private TextMeshProUGUI score;
    [SerializeField]
    private TextMeshProUGUI waveNum;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        lifeRemain.text = "Life Remainining = " + pController.playerHealth.ToString();
        score.text = "Score = " + pController.playerScore.ToString();
        waveNum.text = "Wave : " + waveController.ongoingWaveNumber.ToString();
    }
}
