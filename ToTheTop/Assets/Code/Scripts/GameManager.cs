using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TextMeshProUGUI _inputField;
    public string nickname;

    [SerializeField] private GameObject validateNickname;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        nickname = null;
    }


    public void StartGame()
    {
        if (nickname != null)
        {
            SceneManager.LoadScene("Level_Interaction");
        }
        else
        {
            validateNickname.SetActive(true);
        }
    }
    public void RegisterNickname()
    {
        nickname = _inputField.text;
    }
    //Scene managing
    public void GotoScene(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void GotoNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GotoPreviousScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}