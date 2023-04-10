using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    private int currentScore;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        IScoreable scoreable = other.GetComponent<IScoreable>();
        if(scoreable != null)
        {
            ScoreCount();
        }
    }

    private void ScoreCount()
    {
        currentScore++;
        Debug.Log($"Object : {this.gameObject.name}  Score: {currentScore}");
    }

}
