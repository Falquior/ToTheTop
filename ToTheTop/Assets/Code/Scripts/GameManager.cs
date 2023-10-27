using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    

    public void StartGame()
    {
        if (UIManager.Instance.nickname != null)
        {
            SceneManager.LoadScene("DialogueSystem");
        }
        else
        {
            UIManager.Instance.ValidateNickname();
        }
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
