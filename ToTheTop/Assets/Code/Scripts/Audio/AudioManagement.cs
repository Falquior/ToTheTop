using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagement : MonoBehaviour
{
    [SerializeField] AudioSource m_Source;
    [SerializeField] AudioClip m_Clip;
    public void ChangeBGM1()
    {
        m_Source.Stop();
        m_Source.clip = m_Clip;
        //m_Source.pitch = 1.5f;
        m_Source.Play();
    }
}
