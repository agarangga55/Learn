using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public string waveNumber;
        public int noOfObjects;
        public GameObject[] typeOfObjects;
        public int spawnInterval;
    }

    private PlayerController pController;

    public Wave[] waves;
    public Transform[] spawnPoints;

    private Wave ongoingWave;
    public int ongoingWaveNumber;

    private float nextSpawnTime;

    private bool isSpawning = true;
    // Start is called before the first frame update
    void Start()
    {
        pController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    private void Update()
    {
        ongoingWave = waves[ongoingWaveNumber];
        WaveSpawn();
        GameObject[] totalObjects = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] totalNPC = GameObject.FindGameObjectsWithTag("NPC");
        if (totalObjects.Length == 0 && totalNPC.Length == 0 && !isSpawning && ongoingWaveNumber+1 != waves.Length)
        {
            ongoingWaveNumber++;
            isSpawning = true;
        }
    }

    void WaveSpawn()
    {
        if (isSpawning && nextSpawnTime < Time.time)
        {
            GameObject randomObject = ongoingWave.typeOfObjects[Random.Range(0, ongoingWave.typeOfObjects.Length)];
            Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(randomObject, randomPoint.position, Quaternion.identity);
            randomObject.GetComponent<EnemyController>().SetDependencies(pController);
            ongoingWave.noOfObjects--;
            nextSpawnTime = Time.time + ongoingWave.spawnInterval;
            if (ongoingWave.noOfObjects == 0)
            {
                isSpawning = false;
            }
        } 
    }
}
