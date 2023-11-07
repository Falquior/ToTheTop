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
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject finishedMissionPanel;
    
    [SerializeField, Tooltip("Drag Raw Image on the right in Dialogue panel")] 
    private RawImage playerPortrait;
    [SerializeField] private Texture playerFullColor;
    [SerializeField] private Texture playerBlackWhite;
    
    public float typingSpeed;

    private bool isPaused;
    public bool playerFall;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        typingSpeed = 0.1f;
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
        SceneManager.LoadScene("Level_Interaction");
        if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
        }
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

    public void BackToMenu()
    {
        SceneManager.LoadScene("UIMenu");
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void SettingsButtonFunction()
    {
        GameManager.Instance.ActivateSettingsPanel();
    }

    public void SetNickname()
    {
        if (GameManager.Instance.inputNickname != null)
        {
            GameManager.Instance.SetNickname();
        }
        else
        {
            GameManager.Instance.inputNickname = _inputField;
            GameManager.Instance.SetNickname();
        }
    }
    
}
