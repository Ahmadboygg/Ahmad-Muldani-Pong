using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("In Game Scene");
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
