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
            var ballSpeedUpObject = GameObject.FindObjectsOfType<BallSpeedUp>();
            foreach(BallSpeedUp obj in ballSpeedUpObject)
            {
                Destroy(obj.gameObject);
            }
            speedable.ResetBallSpeedUp();
            BallSpeedUpSpawnCount.ResetCurrentSpeedUpSpawn();

            var paddleSpeedUpObject = GameObject.FindObjectsOfType<PaddleSpeedUp>();
            foreach(PaddleSpeedUp obj in paddleSpeedUpObject)
            {
                Destroy(obj.gameObject);
            }
            speedable.ResetPaddleSpeedUp();
            PaddleSpeedUpSpawnCount.ResetCurrentSpeedUpSpawn();
        }

        ISizeable sizeable = other.GetComponent<ISizeable>();
        if(sizeable != null)
        {
            var paddleSizeUpObject = GameObject.FindObjectsOfType<PaddleSizeUp>();
            foreach(PaddleSizeUp obj in paddleSizeUpObject)
            {
                Destroy(obj.gameObject);
            }
            sizeable.ResetToDeffaultSize();
            PaddleSizeUpSpawnCount.ResetCurrentSizeUpSpawn();
        }
    }

    private void ScoreCount()
    {
        currentScore++;
        Debug.Log($"Object : {this.gameObject.name}  Score: {currentScore}");
    }
}
