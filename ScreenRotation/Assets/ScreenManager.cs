using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScreenManager : MonoBehaviour
{
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            Screen.orientation = ScreenOrientation.LandscapeLeft;
            Debug.Log("Wtf");
        }
        else if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            Screen.orientation = ScreenOrientation.Portrait;
            Debug.Log("Yolo");
        }
    }

    public void ChangeSceen()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            SceneManager.LoadScene(1);
            Debug.Log("Lol");
        }
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadScene(0);
            Debug.Log("GGWP");
        }
    }
    private void Update()
    {
        if(Screen.orientation == ScreenOrientation.LandscapeLeft)
        {
            text.text = "Landscape";
            Debug.Log("Swag");
        }
        if (Screen.orientation == ScreenOrientation.Portrait)
        {
            text.text = "Portrait";
            Debug.Log("Haha");
        }
    }

}
