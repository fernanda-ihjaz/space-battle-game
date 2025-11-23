using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public float minSpawnDelay = 1.5f;
    public float maxSpawnDelay = 3.5f;

    private bool canSpawn = true;

    private Camera cam;
    private float nextSpawnTime;

    private void OnEnable()
    {
        PlayerController.OnPlayerDied += StopSpawning;
    }

    private void OnDisable()
    {
        PlayerController.OnPlayerDied -= StopSpawning;
    }

    void Start()
    {
        cam = Camera.main;
        ScheduleNextSpawn();
    }

    void Update()
    {
        if (!canSpawn)
            return;

        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            ScheduleNextSpawn();
        }
    }

    void ScheduleNextSpawn()
    {
        nextSpawnTime = Time.time + Random.Range(minSpawnDelay, maxSpawnDelay);
    }

    void SpawnEnemy()
    {
        if (enemyPrefabs.Length == 0) return;

        float camHeight = cam.orthographicSize;
        float camWidth = camHeight * cam.aspect;

        float spawnX = cam.transform.position.x + camWidth + 1f;

        float spawnY = Random.Range(
            cam.transform.position.y - camHeight,
            cam.transform.position.y + camHeight
        );

        Vector3 spawnPos = new Vector3(spawnX, spawnY, 0);

        int index = Random.Range(0, enemyPrefabs.Length);

        Instantiate(enemyPrefabs[index], spawnPos, Quaternion.identity);
    }

    private void StopSpawning()
    {
        canSpawn = false;
    }
}
