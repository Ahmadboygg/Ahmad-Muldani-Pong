using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpeedUp : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) 
    {
        ISpeedable speedable = other.GetComponent<ISpeedable>();
        if(speedable != null)
        {
            speedable.SpeedUp();
            SpeedUp.currentSpeedUpSpawn--;
            Destroy(gameObject);
        }
    }
}
