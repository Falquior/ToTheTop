using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


[DefaultExecutionOrder(100)]
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private GameObject _player;
    private PlayerMovement _pc;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject finishedMissionPanel;
    
    [SerializeField, Tooltip("Drag Raw Image on the right in Dialogue panel")] 
    private RawImage playerPortrait;
    [SerializeField] private Texture playerFullColor;
    [SerializeField] private Texture playerBlackWhite;

    private bool isPaused;
    public bool playerFall;
    private bool isStarting;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _pc = _player.GetComponent<PlayerMovement>();
        _pc.enabled = false;
        isStarting = true;
        menuPanel.SetActive(true);
        pausePanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void ActivatePlayerMovement()
    {
        if (_pc.isActiveAndEnabled)
        {
            _pc.enabled = false;
        }
        else
        {
            _pc.enabled = true;
        }
    }
    
    public void StartGame()
    {
        _pc.enabled = true;
        isStarting = false;
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void ResumeGame()
    {
        if (isStarting)
        {
            menuPanel.SetActive(true);
        }
        else
        {
            pausePanel.SetActive(true);
        }
    }

    public void SettingsButtonFunction()
    {
        settingsPanel.SetActive(true);
    }
    
    
}
