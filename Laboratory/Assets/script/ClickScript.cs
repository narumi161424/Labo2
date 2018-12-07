﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ClickScript : MonoBehaviour
{
    public AudioSource button_AudioSource;



    // Use this for initialization
    void Start()
    {
        button_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ButtonClick()
    {
        button_AudioSource.PlayOneShot(button_AudioSource.clip);

    
    }
}