using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public string npcName;
    [SerializeField, Tooltip("Drag Raw Image on the left in Dialogue panel")] 
    private RawImage npcPortrait;
    [SerializeField] private Texture npcFullColor;
    [SerializeField] private Texture npcBlackWhite;

    public string GetNpcName()
    {
        return npcName;
    }

    public void ShowNpcPortrait(bool isPlayer)
    {
        if (!isPlayer)
        {
            npcPortrait.texture = npcFullColor;
        }
        else
        {
            npcPortrait.texture = npcBlackWhite;
        }
    }
}
