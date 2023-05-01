using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("In Game Scene");
        BallSpeedUpSpawnCount.ResetCurrentSpeedUpSpawn();
        PaddleSpeedUpSpawnCount.ResetCurrentSpeedUpSpawn();
        PaddleSizeUpSpawnCount.ResetCurrentSizeUpSpawn();
        Debug.Log("Created by: Ahmad Boy");
    }

    public void CreditButton()
    {
        SceneManager.LoadScene("Credit Scene");
    }

    public void ExitButton()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }
}
