using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpeedUpSpawner : MonoBehaviour
{
    public GameObject ballSpeedUpPrefab;
    public int maxSpeedUpSpawn = 0;
    public int _currentSpeedUpSpawn => currentSpeedUpSpawn;
    public float spawnAreaXOffset;
    public float spawnAreaYOffset;
    public float spawnTime = 0f;

    private int currentSpeedUpSpawn;
    private float spawnAreaX;
    private float spawnAreaY;
    private float currentSpawnTime;
    private Vector2 ballSpeedUpPosition;
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
        if(SpeedUp.currentSpeedUpSpawn < maxSpeedUpSpawn )
        {
            currentSpawnTime -= Time.deltaTime;

            if(currentSpawnTime <= 0f)
            {
                SpeedUp.currentSpeedUpSpawn++;
                GetBallSpeedUpCoordinate();
                Instantiate(ballSpeedUpPrefab, ballSpeedUpPosition, Quaternion.identity);
                currentSpawnTime = spawnTime;
                Debug.Log($"{GetBallSpeedUpCoordinate()}");
            }
        }
    }

    Vector2 GetBallSpeedUpCoordinate()
    {
        var GenerateCoordinate = new Vector2 (Random.Range(-spawnAreaX, spawnAreaX), Random.Range(-spawnAreaY,spawnAreaY));
        ballSpeedUpPosition = GenerateCoordinate;
        return ballSpeedUpPosition;
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireCube(Vector3.zero,ballSpeedUpPosition);
    }
}
