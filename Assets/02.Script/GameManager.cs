using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float playTime = 180.0f;
    private float timer;
    public GameObject[] enemyPrefabs; 
    public Transform spawnArea; 
    public float spawnTime = 5.0f; 
    public float spawnDelay = 2.0f; // 시작 후 최초 생성 지연 시간
    public GameObject player;

    private void Start()
    {
        timer = 0.0f;
        InvokeRepeating("SpawnEnemy", spawnDelay, spawnTime);
    }
    
    void Update() 
    {
        timer += Time.deltaTime;

        if(timer >= playTime)
        {
            SceneManager.LoadScene("ClearScene");
        }
    }

    private void SpawnEnemy()
    {
        // 랜덤한 적 프리팹 선택
        GameObject randomEnemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

        // 랜덤한 위치 계산
        Vector3 randomPosition = GetRandomSpawnPosition();

        // 적 생성
        GameObject enemy = Instantiate(randomEnemyPrefab, randomPosition, Quaternion.identity);
        EnemyController enemyController = enemy.GetComponent<EnemyController>();
        if (enemyController != null)
        {
            enemyController.player = player.transform;
        }
        RunningEnemyController runningEnemyController = enemy.GetComponent<RunningEnemyController>();

        if (runningEnemyController != null)
        {
            runningEnemyController.player = player.transform;
            enemy.SetActive(true);
        }
        
    }

    private Vector3 GetRandomSpawnPosition()
    {
        Vector3 spawnCenter = spawnArea.position;
        Vector3 spawnExtents = spawnArea.localScale * 0.8f;

        float randomX = Random.Range(-spawnExtents.x, spawnExtents.x);
        float randomZ = Random.Range(-spawnExtents.z, spawnExtents.z);
        float Height = 15.0f;

        Vector3 randomSpawnPosition = spawnCenter + new Vector3(randomX, Height, randomZ);

        return randomSpawnPosition;
    }
}