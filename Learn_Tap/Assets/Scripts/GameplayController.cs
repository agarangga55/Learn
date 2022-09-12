using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    [SerializeField]
    private GameObject Enemy;
    [SerializeField]
    private GameObject NPC;

    [SerializeField]
    private float spawnInterval;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner(spawnInterval, Enemy));
        StartCoroutine(Spawner(4, NPC));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Spawner(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newObject = Instantiate(enemy, new Vector2(-10, Random.Range(-5f, 5)), Quaternion.identity);
        StartCoroutine(Spawner(interval, enemy));
    }
}
