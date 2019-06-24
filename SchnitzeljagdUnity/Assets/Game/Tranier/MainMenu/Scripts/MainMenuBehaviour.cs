using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBehaviour : MonoBehaviour
{
    private void Start()
    {
        //Only Portrait modus.
        Screen.orientation = ScreenOrientation.Portrait;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(20);
    }
    public void QuitGame()
    {
        Debug.Log("Game Quit!");
        Application.Quit();
    }

}
