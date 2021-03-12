using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip buttonPress;


    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void playButtonSound()
    {
        audioSource.PlayOneShot(buttonPress);
    }
}
