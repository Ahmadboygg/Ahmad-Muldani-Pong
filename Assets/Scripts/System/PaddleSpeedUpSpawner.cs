using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleSpeedUpSpawner : MonoBehaviour
{
    public GameObject PaddleSpeedUpPrefab;
    public int maxSpeedUpSpawn = 0;
    public int _currentSpeedUpSpawn => currentSpeedUpSpawn;
    public float spawnAreaXOffset;
    public float spawnAreaYOffset;
    public float spawnTime = 0f;

    private int currentSpeedUpSpawn;
    private float spawnAreaX;
    private float spawnAreaY;
    private float currentSpawnTime;
    private Vector2 paddleSpeedUpPosition;
    void Awake()
    {
        spawnAreaX = Camera.main.orthographicSize - spawnAreaXOffset;
        spawnAreaY = Camera.main.orthographicSize - spawnAreaYOffset;
    }

    void Start()
    {
        currentSpawnTime = spawnTime;
    }

    void Update()
    {
        if(PaddleSpeedUpSpawnCount.currentSpeedUpSpawn < maxSpeedUpSpawn )
        {
            currentSpawnTime -= Time.deltaTime;

            if(currentSpawnTime <= 0f)
            {
                PaddleSpeedUpSpawnCount.currentSpeedUpSpawn++;
                GetPaddleSpeedUpCoordinate();
                Instantiate(PaddleSpeedUpPrefab, paddleSpeedUpPosition, Quaternion.identity);
                currentSpawnTime = spawnTime;
                Debug.Log($"{GetPaddleSpeedUpCoordinate()}");
            }
        }
    }

    Vector2 GetPaddleSpeedUpCoordinate()
    {
        var GenerateCoordinate = new Vector2 (Random.Range(-spawnAreaX, spawnAreaX), Random.Range(-spawnAreaY,spawnAreaY));
        paddleSpeedUpPosition = GenerateCoordinate;
        return paddleSpeedUpPosition;
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireCube(Vector3.zero,paddleSpeedUpPosition);
    }
}
