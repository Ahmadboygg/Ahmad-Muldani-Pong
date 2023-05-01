using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void Resume()
    {
        gameObject.SetActive(false);
        DisableTimePause();
    }

    public void Restart()
    {
        SceneManager.LoadScene("In Game Scene");
        gameObject.SetActive(false);
        BallSpeedUpSpawnCount.ResetCurrentSpeedUpSpawn();
        PaddleSpeedUpSpawnCount.ResetCurrentSpeedUpSpawn();
        PaddleSizeUpSpawnCount.ResetCurrentSizeUpSpawn();
        DisableTimePause();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Main Menu Scene");
        gameObject.SetActive(false);
        DisableTimePause();
    }

    private void DisableTimePause()
    {
        Time.timeScale = 1f;
    }
}
