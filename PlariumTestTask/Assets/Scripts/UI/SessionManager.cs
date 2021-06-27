using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SessionManager : MonoBehaviour
{
    #region Singleton

    public static SessionManager instance;

    public RestartMenu restartMenu;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Module Manager found");
            return;
        }

        instance = this;
    }

    #endregion

    public void GameWon()
    {
        restartMenu.ShowWinPanel();
        Time.timeScale = 0f;
    }

    public void GameLose()
    {
        restartMenu.ShowLosePanel();
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
