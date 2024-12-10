using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip winSound;  
    public AudioClip lossSound; 
    public AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayWinSound()
    {
        PlaySound(winSound);
    }

    public void PlayLossSound()
    {
        PlaySound(lossSound);
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip == null)
        {
            Debug.LogWarning("No audio clip assigned!");
            return;
        }

        audioSource.clip = clip;
        audioSource.Play();
    }
}
