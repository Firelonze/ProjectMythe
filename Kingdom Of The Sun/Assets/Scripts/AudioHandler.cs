using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    //audio source 1: SFX
    //audio source 2: footsteps
    private AudioSource[] sources;
    [SerializeField] private AudioClip[] audioClips;

    private void Start()
    {
        sources = GetComponents<AudioSource>();
    }

    public void PlayAudioSFX(int i)
    {
        sources[0].clip = audioClips[i];
        sources[0].Play();
    }

    public void StopAudioSFX()
    {
        sources[0].Stop();
    }

    public void PlayAudioFootStep()
    {

    }
}