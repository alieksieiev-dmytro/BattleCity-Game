using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartMenu : MonoBehaviour
{
    public static bool GameIsOver = false;

    public GameObject restartMenuUI;

    public Text winText;
    public Text loseText;

    private void Update()
    {
        
    }

    public void ShowWinPanel()
    {
        restartMenuUI.SetActive(true);
        winText.gameObject.SetActive(true);
    }

    public void ShowLosePanel()
    {
        restartMenuUI.SetActive(true);
        loseText.gameObject.SetActive(true);
    }

    public void RestartButtonClick()
    {
        SessionManager.instance.RestartGame();
    }
}
