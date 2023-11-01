using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
public class DialogueBox : MonoBehaviour
{
    [SerializeField] private string npcName;
    private string playerName = UIManager.Instance.nickname;
    [SerializeField] private bool isPlayer;
    [SerializeField] private bool mission;
    //para dialogos que son de la misma persona pero diferente cuadro = "..."
    //para determinar salida de la conversacion = "chaito"
    [SerializeField, TextArea(4, 6)] public string textBox;
}
