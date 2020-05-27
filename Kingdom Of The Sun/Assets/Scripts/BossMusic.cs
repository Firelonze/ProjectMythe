using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMusic : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField] private AudioClip[] audioClips;

    private int currentClip;

    private void Awake()
    {
        audioSource.GetComponent<AudioSource>();
    }
    
    private void PlayAudio(audioClips[currentClip])
    {

    }
}
