using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneManager : MonoBehaviour
{
    public SceneManager scene;

    public void NewGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
    public  void NextLevel()
    {
        Scene currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        int SceneIndex = currentScene.buildIndex;
        int LoadNextLevel = SceneIndex + 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(LoadNextLevel);
    }

    public void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void ExitThis()
    {
        Application.Quit();
    }
}

