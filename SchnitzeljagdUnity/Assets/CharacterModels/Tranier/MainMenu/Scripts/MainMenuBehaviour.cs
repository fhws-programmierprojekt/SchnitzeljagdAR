﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBehaviour : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(20);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}