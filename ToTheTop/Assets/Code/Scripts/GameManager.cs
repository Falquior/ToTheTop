using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
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
            SceneManager.LoadScene("Player_Test");
        }
        else
        {
            validateNickname.SetActive(true);
        }
    }

    public void RegisterNickname(string inputNickname)
    {
        nickname = inputNickname;
    }
    
    public void GotoScene(string level){
        SceneManager.LoadScene(level);
    }

    public void GotoNextScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GotoPreviousScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
