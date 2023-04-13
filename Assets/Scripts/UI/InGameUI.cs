using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUI : MonoBehaviour
{
    public GameObject gameOverUI;
    private ScoreTrigger leftPaddleScoreTrigger;
    private ScoreTrigger rightPaddleScoreTrigger;

    void Awake() 
    {
        leftPaddleScoreTrigger = GameObject.Find("Trigger Score Kanan").GetComponent<ScoreTrigger>();
        rightPaddleScoreTrigger = GameObject.Find("Trigger Score Kiri").GetComponent<ScoreTrigger>();
        gameOverUI.SetActive(false); 
    }
    void Update()
    {
        if(leftPaddleScoreTrigger._currentScore >= leftPaddleScoreTrigger.maxScore)
        {
            gameOverUI.SetActive(true);
            Time.timeScale = 0f;
        }
        else if(rightPaddleScoreTrigger._currentScore >= rightPaddleScoreTrigger.maxScore)
        {
            gameOverUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
