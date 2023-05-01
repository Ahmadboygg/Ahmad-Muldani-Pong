using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleSizeUp : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) 
    {
        ISizeable sizeable = other.GetComponent<ISizeable>();
        if(sizeable != null)
        {
            sizeable.IncreaseSize();
            PaddleSizeUpSpawnCount.currentSizeUpSpawn--;
            Destroy(gameObject);
        }
    }
}
