using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float secondsBetweenSpawns = 3f;
    [SerializeField] EnemyMovement enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RepeateddlySpawnEnemy());
    }

    IEnumerator RepeateddlySpawnEnemy()
    {
        while(true)
        {
            print("enemy spawned");
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }        
    }
}
