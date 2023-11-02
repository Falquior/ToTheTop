using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject gameOverPanel;

    private bool isPaused;
    public bool playerFall;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    void PauseGame()
    {
        if (!isPaused)
        {
            pausePanel.SetActive(true);
            isPaused = true;
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
            isPaused = false;
        }
    }

    void GameOver()
    {
        if (playerFall)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    void ActivateSettingsPanel()
    {
        settingsPanel.SetActive(true);
    }
    
    
}
