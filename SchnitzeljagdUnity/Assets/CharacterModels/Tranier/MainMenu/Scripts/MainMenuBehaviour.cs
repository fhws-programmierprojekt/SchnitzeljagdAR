using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBehaviour : MonoBehaviour
{
    private void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(20);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
