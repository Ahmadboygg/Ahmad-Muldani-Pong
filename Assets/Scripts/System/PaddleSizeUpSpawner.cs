using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleSizeUpSpawner : MonoBehaviour
{
    public GameObject PaddleSizeUpPrefab;
    public int maxSizeUpSpawn = 0;
    public int _currentSizeUpSpawn => currentSizeUpSpawn;
    public float spawnAreaXOffset;
    public float spawnAreaYOffset;
    public float spawnTime = 0f;

    private int currentSizeUpSpawn;
    private float spawnAreaX;
    private float spawnAreaY;
    private float currentSpawnTime;
    private Vector2 paddleSizeUpPosition;
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
        if(PaddleSizeUpSpawnCount.currentSizeUpSpawn < maxSizeUpSpawn )
        {
            currentSpawnTime -= Time.deltaTime;

            if(currentSpawnTime <= 0f)
            {
                PaddleSizeUpSpawnCount.currentSizeUpSpawn++;
                GetPaddleSizeUpCoordinate();
                Instantiate(PaddleSizeUpPrefab, paddleSizeUpPosition, Quaternion.identity);
                currentSpawnTime = spawnTime;
                Debug.Log($"{GetPaddleSizeUpCoordinate()}");
            }
        }
    }

    Vector2 GetPaddleSizeUpCoordinate()
    {
        var GenerateCoordinate = new Vector2 (Random.Range(-spawnAreaX, spawnAreaX), Random.Range(-spawnAreaY,spawnAreaY));
        paddleSizeUpPosition = GenerateCoordinate;
        return paddleSizeUpPosition;
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireCube(Vector3.zero,paddleSizeUpPosition);
    }
}
