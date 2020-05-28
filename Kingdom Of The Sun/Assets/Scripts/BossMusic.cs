using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMusic : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField] private AudioClip[] audioClips;

    private int currentClip = 0;

    private float timer;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        PlayAudio();

        timer -= Time.deltaTime;

        if (timer < 0)
        {
            PlayAudio();
        }
    }

    public void SetMusic(int tempInt)
    {
        currentClip = tempInt;
    }

    private void PlayAudio()
    {
        audioSource.clip = audioClips[currentClip];
        audioSource.Play();
        timer = audioSource.clip.length;
        if(currentClip == 0)
        {
            currentClip++;
        }
    }
}
