using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab enemy yang akan di-spawn
    public int enemyCount = 5; // Jumlah enemy yang akan di-spawn
    public float spawnRadius = 10f; // Radius spawn area
    public float minDistanceFromPlayer = 3f; // Jarak minimum dari player
    public Transform player; // Referensi ke karakter player

    void Start()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            Vector3 spawnPosition = GetValidSpawnPosition();
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }

    Vector3 GetValidSpawnPosition()
    {
        Vector3 spawnPosition;
        do
        {
            float randomX = Random.Range(-spawnRadius, spawnRadius);
            float randomZ = Random.Range(-spawnRadius, spawnRadius);
            spawnPosition = new Vector3(randomX, 0, randomZ) + transform.position;
        } while (Vector3.Distance(spawnPosition, player.position) < minDistanceFromPlayer);
        
        return spawnPosition;
    }

    void OnDrawGizmos()
    {
        if (player != null)
        {
            // Draw the spawn radius
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, spawnRadius);

            // Draw the minimum distance from the player
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(player.position, minDistanceFromPlayer);
        }
    }
}
