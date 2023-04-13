using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    public TMP_Text winnerTxt;
    public TMP_Text scoreTxt;
    private ScoreTrigger leftPaddleScoreTrigger;
    private ScoreTrigger rightPaddleScoreTrigger;

    void Awake()
    {
        leftPaddleScoreTrigger = GameObject.Find("Trigger Score Kanan").GetComponent<ScoreTrigger>();
        rightPaddleScoreTrigger = GameObject.Find("Trigger Score Kiri").GetComponent<ScoreTrigger>();
    }

    void Start()
    {
        WinnerHandle();
        ScoreHandle();
        StartCoroutine(BackToMainMenu());
    }

    void WinnerHandle()
    {
        if(leftPaddleScoreTrigger._currentScore >= leftPaddleScoreTrigger.maxScore)
        {
            winnerTxt.text = "Paddle Kiri Menang !";
        }
        else if(rightPaddleScoreTrigger._currentScore >= rightPaddleScoreTrigger.maxScore)
        {
            winnerTxt.text = "Paddle Kanan Menang !";
        }
    }

    void ScoreHandle()
    {
        scoreTxt.text = $"Dengan Skor {leftPaddleScoreTrigger._currentScore} : {rightPaddleScoreTrigger._currentScore}";
    }

    IEnumerator BackToMainMenu()
    {
        yield return new WaitForSecondsRealtime(3f);
        SceneManager.LoadScene("Main Menu Scene");
        Time.timeScale = 1f;
    }
}
