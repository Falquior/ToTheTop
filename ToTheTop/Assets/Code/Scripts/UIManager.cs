using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    private void Start()
    {
        Time.timeScale = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name == "Level_Interaction")
        {
            PauseGame();
        }
    }
    
    public void StartGame()
    {
        Time.timeScale = 1;
    }

    public void PauseGame()
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
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Level_Interaction");
    }


    public void ResumeGame()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
        }
    }

    public void SettingsButtonFunction()
    {
        settingsPanel.SetActive(true);
    }
    
    
}
