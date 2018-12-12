﻿using UnityEngine;
using System.Collections;

public class AudioPlayer : MonoBehaviour
{

    public AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void PlaySE_touch()
    {
        audioSource.Play();
    }
}