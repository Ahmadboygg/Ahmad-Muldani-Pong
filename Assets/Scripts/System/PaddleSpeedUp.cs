using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleSpeedUp : MonoBehaviour
{
   void OnTriggerEnter2D(Collider2D other) 
    {
        ISpeedable speedable = other.GetComponent<ISpeedable>();
        if(speedable != null)
        {
            speedable.PaddleSpeedUp();
            PaddleSpeedUpSpawnCount.currentSpeedUpSpawn--;
            Destroy(gameObject);
        }
    }
}
