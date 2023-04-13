using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreTrigger : MonoBehaviour
{
    public int _currentScore => currentScore;
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

        if(currentScore > 9)
        {
            Time.timeScale = 0f;
            Invoke("BackToMainMenu", 2.5f);
        }
    }

    private void BackToMainMenu()
    {
        SceneManager.LoadScene("Main Menu Scene");
    }

}
