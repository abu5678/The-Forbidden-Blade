using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_UI : MonoBehaviour
{
    [SerializeField] private string sceneName = "GameScene";

    public void startGame()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
