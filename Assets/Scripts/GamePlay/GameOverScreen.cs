using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public void showScreen()
    {
        gameObject.SetActive(true);
    }

    public void restartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
