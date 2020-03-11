using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    AudioSource audioSource;

    public AudioClip sfxBg;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic ()
    {
        Debug.Log("Collidiu");
        audioSource.clip = sfxBg;
        audioSource.volume = 0.70f;
        audioSource.Play();
    }
}
