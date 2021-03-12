using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;

    //In-Game sounds
    public AudioClip swordAttack;

    //UI sounds
    public AudioClip buttonPress;


    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    //In-Game sounds
    public void playSwordAttackSound()
    {
        audioSource.PlayOneShot(swordAttack);
    }


    //UI sounds
    public void playButtonSound()
    {
        audioSource.PlayOneShot(buttonPress);
    }
}
