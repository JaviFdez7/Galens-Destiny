using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private float spawnRate = 1f;

    [SerializeField]
    private List<GameObject> enemyPrefabs;
    public List<string> possibleEnemies = new List<string>();

    [SerializeField]
    private bool canSpawn = true;

    [SerializeField]
    public int numberOfEnemy = 1;

    public void Start()
    {
        LoadEnemiesFromResources();

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Spawner());
            canSpawn = false;
        }
    }

    private IEnumerator Spawner()
    {
        if(!canSpawn)
        {
            yield break;
        }
        WaitForSeconds wait = new(spawnRate);
        int spawnedEnemies = 0;
        while (spawnedEnemies < numberOfEnemy)
        {
            yield return wait;
            int rand = Random.Range(0, enemyPrefabs.Count);
            GameObject enemyToSpawn = enemyPrefabs[rand];
            Vector2 spawnPosition = new Vector2(transform.position.x + Random.Range(-8f, 8f), transform.position.y + Random.Range(-5f, 5f));
            Instantiate(enemyToSpawn, spawnPosition, Quaternion.identity);
            
            spawnedEnemies++;
        }
    }

    public void LoadEnemiesFromResources()
    {
        enemyPrefabs = new List<GameObject>();
        foreach (string enemy in possibleEnemies)
        {
            try
            {
                GameObject enemyPrefab = Resources.Load<GameObject>("Prefabs/Enemy/" + enemy);
                enemyPrefabs.Add(enemyPrefab);
            }
            catch (System.Exception)
            {
                Debug.LogError("Failed to load enemy " + enemy);
            }
        }
        canSpawn = true;
    }
}
