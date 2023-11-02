using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider2D))]
public class DialogueSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private RawImage npcPortrait;
    [SerializeField] private RawImage playerPortrait;
    [SerializeField] private Texture npcFullColor;
    [SerializeField] private Texture npcBlackWhite;
    [SerializeField] private Texture playerFullColor;
    [SerializeField] private Texture playerBlackWhite;
    [SerializeField] private GameObject exclamationMark;
    [SerializeField] private GameObject confirmationPanel;
    [SerializeField] private TextBox[] textLine;
    [SerializeField] private string playerNickname;
    [SerializeField] private string npcName;
    private string speakerName;

    private bool playerDetected;
    private bool isTalking;
    private int lineIndex;
    [SerializeField, Range(0.05f, 0.5f)] private float typingTime;
    

    private void Update()
    {
        if (playerDetected && Input.GetKeyDown(KeyCode.E))
        {
            if (!isTalking)
            {
                StartDialogue();
            }
            else if (dialogueText.text == $"{speakerName}: "+ textLine[lineIndex].text)
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = $"{speakerName}: {textLine[lineIndex].text}";
            }
        }
    }

    void StartDialogue()
    {
        isTalking = true;
        dialoguePanel.SetActive(true);
        exclamationMark.SetActive(false);
        lineIndex = 0;
        AsignName();
    }

    void NextLine()
    {
        lineIndex++;
        if (lineIndex < textLine.Length)
        {
            AsignName();
        }
        else
        {
            isTalking = false;
            dialoguePanel.SetActive(false);
            exclamationMark.SetActive(true);
            confirmationPanel.SetActive(true);
        }
    }
    

    void AsignName()
    {
        if (textLine[lineIndex].isPlayer)
        {
            npcPortrait.texture = npcBlackWhite;
            playerPortrait.texture = playerFullColor;
            StartCoroutine(TypeTextLine(playerNickname));
            speakerName = playerNickname;
        }
        else
        {
            npcPortrait.texture = npcFullColor;
            playerPortrait.texture = playerBlackWhite;
            StartCoroutine(TypeTextLine(npcName));
            speakerName = npcName;
        }
    }
    
    IEnumerator TypeTextLine(string speaker)
    {
        dialogueText.text = string.Empty;
        dialogueText.text = $"{speaker}: ";
        foreach (char character in textLine[lineIndex].text)
        {
            dialogueText.text += character;
            yield return new WaitForSeconds(typingTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            playerDetected = true;
            exclamationMark.SetActive(true);
        }
    }
    

    private void OnTriggerExit2D(Collider2D other)
    {
        playerDetected = false;
        exclamationMark.SetActive(false);
    }
    

}

[System.Serializable]

public class TextBox
{
    [TextArea(4, 12)] public string text;
    public bool isPlayer;
}
