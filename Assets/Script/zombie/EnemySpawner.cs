using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float Radius = 10f;
    private int curWave = 1;
    private int countOfEnemiesStartValue = 5;
    private float WaveDuration = 10f;
    public Transform player;
    public TextManager waveText;
	public GroundController ground;
    private List<GameObject> spawnedEnemies = new List<GameObject>();
    
    void Start()
    {
		ground.Start();
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
			ground.ChangeGround();

			if (curWave == 1) {
				yield return new WaitForSeconds(3f);
			}

            Debug.Log("Wave # " + curWave);
            
            waveText.StartWave(curWave, WaveDuration);
            
            int currentCountOfEnemy = countOfEnemiesStartValue + (curWave - 1) * 2;

            for (int i = 0; i < currentCountOfEnemy; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(0.5f);
            }
            
            yield return new WaitForSeconds(WaveDuration);
            
            ClearOldEnemies();

            yield return new WaitForSeconds(3f);
            
            WaveDuration += 2f;
            curWave += 1;
        }
    }

    void SpawnEnemy()
    {
        Vector3 spawnPosition = new Vector3(
            transform.position.x + Random.Range(-Radius, Radius),
            0f,
            transform.position.z + Random.Range(-Radius, Radius)
        );

        GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        newEnemy.GetComponent<Enemy>().player = player;
        
        spawnedEnemies.Add(newEnemy);
    }

    void ClearOldEnemies()
    {
        foreach (GameObject enemy in spawnedEnemies)
        {
            if (enemy != null)
            {
                Destroy(enemy);
            }
        }

        spawnedEnemies.Clear();
    }
}