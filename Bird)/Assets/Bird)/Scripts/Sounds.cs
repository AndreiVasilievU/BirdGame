using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    [SerializeField]
    AudioClip musicClip;
    [SerializeField]
    public AudioClip[] soundClip;

    [SerializeField]
    AudioSource musicSource;
    [SerializeField]
    AudioSource soundSource;
    [SerializeField]
    AudioSource sawSource;

    private void Start()
    {
        musicSource.clip = musicClip;
        musicSource.Play();
    }

    public void PlaySound(AudioClip _audioClip)
    {
        soundSource.PlayOneShot(_audioClip);
    }
    public void StopSawSound()
    {
        sawSource.Pause();
    }
    public void PlaySawSound(AudioClip _sawAudioClip)
    {
        sawSource.PlayOneShot(_sawAudioClip);
    }
}
