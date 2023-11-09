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
    [SerializeField] private GameObject exclamationMark;
    [SerializeField] private GameObject confirmationPanel;
    [SerializeField] private TextBox[] textLine;
    [SerializeField, Tooltip("Drag the attached NPC into this dialogue system")]
    private NPC _npc;
    private string playerNickname;
    private string npcName;
    private string speakerName;

    private bool playerDetected;
    private bool isTalking;
    private int lineIndex;
    private float typingTime;
    private AudioSource talkSound;

    private void Start()
    {
        talkSound = GetComponent<AudioSource>();
        typingTime = 0.02f;
        speakerName = "";
        playerNickname = GameManager.Instance.GetNickname();
        _npc = GetComponent<NPC>();
        npcName = _npc.GetNpcName();
    }


    private void Update()
    {
        if (playerDetected && Input.GetKeyDown(KeyCode.E) && !confirmationPanel.activeSelf)
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
        UIManager.Instance.ActivatePlayerMovement();
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
            _npc.ShowNpcPortrait(textLine[lineIndex].isPlayer);
            UIManager.Instance.ShowPlayerPortrait(textLine[lineIndex].isPlayer);
            StartCoroutine(TypeTextLine(playerNickname));
            speakerName = playerNickname;
        }
        else
        {
            _npc.ShowNpcPortrait(textLine[lineIndex].isPlayer);
            UIManager.Instance.ShowPlayerPortrait(textLine[lineIndex].isPlayer);
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
            talkSound.Play();
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
