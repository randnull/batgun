using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 5f;
    public float spawnRadius = 10f;
    public Transform player; 

    private int TargetEnemyCount = 5;
    private int EnemyCount = 0;

    void Update()
    {
        if (EnemyCount < TargetEnemyCount)
        {
            SpawnEnemy();
            EnemyCount += 1;
        }
    }

    void SpawnEnemy()
    {
        Vector3 spawnPosition = new Vector3(
            transform.position.x + Random.Range(-spawnRadius, spawnRadius),
            0f,
            transform.position.z + Random.Range(-spawnRadius, spawnRadius)
        );

        GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        newEnemy.GetComponent<EnemyMovement>().player = player;
    }
}