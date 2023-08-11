using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private float spawnRate = 1f;

    [SerializeField]
    private GameObject[] enemyPrefabs;

    [SerializeField]
    private bool canSpawn = true;

    [SerializeField]
    private int numberOfEnemy = 1;

    private void Start() {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner(){
        WaitForSeconds wait = new WaitForSeconds(spawnRate);
        int spawnedEnemies = 0;
        while(canSpawn && (spawnedEnemies!=numberOfEnemy)) {
            yield return wait;
            int rand =  Random.Range(0, enemyPrefabs.Length);
            GameObject enemyToSpawn = enemyPrefabs[rand];

            Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
            spawnedEnemies = spawnedEnemies + 1;
        }
    }

}
