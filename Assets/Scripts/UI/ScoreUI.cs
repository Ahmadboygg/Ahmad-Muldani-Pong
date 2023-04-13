using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    public TMP_Text scoreTxt;
    private int leftPaddleScore;
    private int rightPaddleScore;

    void Update()
    {
        leftPaddleScore = GameObject.Find("Trigger Score Kanan").GetComponent<ScoreTrigger>()._currentScore;
        rightPaddleScore = GameObject.Find("Trigger Score Kiri").GetComponent<ScoreTrigger>()._currentScore;
        scoreTxt.text = $"{leftPaddleScore} : {rightPaddleScore}";
    }
}
