using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonSelector : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    [SerializeField] private GameObject selector;
    
    public void OnSelect(BaseEventData eventData)
    {
        selector.SetActive(true);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        selector.SetActive(false);
    }
}
