using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
   // [SerializeField]
   // private GameObject Enemy;
    [SerializeField]
    private EnemyController NPC;
    [SerializeField]
    private EnemyController enemy;
    [SerializeField]
    private PlayerController pController;

    [SerializeField]
    private float spawnInterval;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner(spawnInterval, enemy));
        StartCoroutine(Spawner(Random.Range(5,10), NPC));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Spawner(float interval, EnemyController enemy)
    {
        yield return new WaitForSeconds(interval);
        EnemyController newObject = Instantiate(enemy, new Vector2(-10, Random.Range(-5f, 5)), Quaternion.identity);
        newObject.SetDependencies(pController);
        StartCoroutine(Spawner(interval, enemy));
    }
}
