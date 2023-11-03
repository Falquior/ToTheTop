using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

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

    public void RegisterNickname(string inputNick)
    {
        nickname = inputNick;
    }

    public void ValidateNickname()
    {
        validateNickname.SetActive(true);
    }
}
