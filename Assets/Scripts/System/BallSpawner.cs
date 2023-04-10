using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefabs = null;
    public float spawnTime = 0f;
    private float currentSpawnTime;

    void Start() 
    {
        currentSpawnTime = spawnTime;
    }

    void Update()
    {
        if(GameObject.Find("Bola(Clone)") == null)
        {
            currentSpawnTime -= Time.deltaTime;

            if(currentSpawnTime <= 0f)
            {
                Instantiate(ballPrefabs, Vector2.zero, Quaternion.identity);
                currentSpawnTime = spawnTime;
            }
        }
    }
}
