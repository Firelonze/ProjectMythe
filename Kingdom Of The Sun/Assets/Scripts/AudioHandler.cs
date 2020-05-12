using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip[] audioClips;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio(int i)
    {
        audioSource.clip = audioClips[i];
        audioSource.Play();
    }

    public void StopAudio()
    {
        audioSource.Stop();
    }
}
