using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject finishedMissionPanel;



    [SerializeField, Tooltip("Drag Raw Image on the right in Dialogue panel")] 
    private RawImage playerPortrait;
    [SerializeField] private Texture playerFullColor;
    [SerializeField] private Texture playerBlackWhite;

    private bool isPaused;
    public bool playerFall;

    private void Awake()
    {
        Instance = this;
    }

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
    
    public void ShowPlayerPortrait(bool isPlayer)
    {
        if (isPlayer)
        {
            playerPortrait.texture = playerFullColor;
        }
        else
        {
            playerPortrait.texture = playerBlackWhite;
        }
    }

    public void FinishedGame()
    {
        finishedMissionPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Level_Interaction");
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("UIMenu");
    }
    
}
