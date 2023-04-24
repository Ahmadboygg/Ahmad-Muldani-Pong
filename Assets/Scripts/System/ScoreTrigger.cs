using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    public int _currentScore => currentScore;
    public int maxScore;
    private int currentScore;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        IScoreable scoreable = other.GetComponent<IScoreable>();
        if(scoreable != null)
        {
            ScoreCount();
        }

        ISpeedable speedable = other.GetComponent<ISpeedable>();
        if(speedable != null)
        {
            var speedUpObject = GameObject.FindObjectsOfType<BallSpeedUp>();
            foreach(BallSpeedUp obj in speedUpObject)
            {
                Destroy(obj.gameObject);
            }
            speedable.ResetSpeedUp();
            SpeedUp.ResetCurrentSpeedUpSpawn();
        }
    }

    private void ScoreCount()
    {
        currentScore++;
        Debug.Log($"Object : {this.gameObject.name}  Score: {currentScore}");
    }
}
