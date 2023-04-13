using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credit : MonoBehaviour
{
    void Start()
    {
        Invoke("BackToMainMenu", 2f);
    }

    void BackToMainMenu()
    {
        SceneManager.LoadScene("Main Menu Scene");
    }
}
