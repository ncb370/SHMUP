using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;
    [SerializeField] private float spawnRate = 2.0f;
    private float spawnTimer;
    public float updatedHealth;
    
    void Awake()
    {
        updatedHealth = 100.0f;
    }
    
    // Update is called once per frame
    void Update()
    {
        SpawnEnemy();
        SpawnEnemy();
        SpawnEnemy();
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        
        Vector3 randomSpawnPosition = new Vector3(Random.Range(GameManager.instance.player.transform.position.x-10f, GameManager.instance.player.transform.position.x + 10f), transform.position.y, Random.Range(GameManager.instance.player.transform.position.z-10f, GameManager.instance.player.transform.position.z + 10f));

        if (Time.time > spawnTimer)
        {
            //Instantiate(enemyPrefab, transform.position, transform.rotation);
            Instantiate(enemyPrefab, randomSpawnPosition, transform.rotation);
            // Make sure enemy is not spawning to close to player
            if (Vector3.Distance(randomSpawnPosition, GameManager.instance.player.transform.position) < .5f)
            {
                Destroy(this);
            }
            else
            {
                updatedHealth += 1;
                spawnTimer = Time.time + spawnRate;
            }
        }
    }
}
