using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonSelector : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    private Button playButton;
    [SerializeField] private GameObject selector;

    private void Start()
    {
        playButton = GetComponent<Button>();
    }

    public void OnSelect(BaseEventData eventData)
    {
        selector.SetActive(true);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        selector.SetActive(false);
    }
}
