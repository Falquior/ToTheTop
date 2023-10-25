using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DialogueSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private GameObject exclamationMark;
    [SerializeField, TextArea(4, 6)] private string[] textLine;

    private bool playerDetected;
    private bool isTalking;
    private int lineIndex;
    [SerializeField, Range(0.05f, 0.5f)] private float typingTime;

    private void Update()
    {
        if (playerDetected && Input.GetKeyDown(KeyCode.Tab))
        {
            if (!isTalking)
            {
                StartDialogue();
            }
            else if (dialogueText.text == textLine[lineIndex])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = textLine[lineIndex];
            }
        }
    }

    void StartDialogue()
    {
        isTalking = true;
        dialoguePanel.SetActive(true);
        exclamationMark.SetActive(false);
        lineIndex = 0;
        StartCoroutine(TypeTextLine());
    }

    void NextLine()
    {
        lineIndex++;
        if (lineIndex < textLine.Length)
        {
            StartCoroutine(TypeTextLine());
        }
        else
        {
            isTalking = false;
            dialoguePanel.SetActive(false);
            exclamationMark.SetActive(true);
        }
    }
    
    IEnumerator TypeTextLine()
    {
        dialogueText.text = string.Empty;

        foreach (char character in textLine[lineIndex])
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
