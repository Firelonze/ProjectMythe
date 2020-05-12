using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioClip[] audioClips;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void playAudio(int i)
    {
        audioSource.clip = audioClips[i];
        audioSource.Play();
    }

    public void stopAudio()
    {
        audioSource.Stop();
    }
}
