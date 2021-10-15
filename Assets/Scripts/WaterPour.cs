﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPour : MonoBehaviour
{
    [SerializeField] private float pourRate = 5.0f;
    [SerializeField] private AudioSource popSound;
    private ParticleSystem waterParticle;
    private Health health;
    private void Start()
    {
        waterParticle = GetComponentInChildren<ParticleSystem>();
        health = GetComponent<Health>();

        health.OnDeath += sheDead;
    }

    private void OnDisable()
    {
        health.OnDeath -= sheDead;
    }
    private void Update()
    {
        var tippedOver = transform.up.y <= 0.7f;
        
        if(tippedOver && !waterParticle.isPlaying)
            waterParticle.Play();

        if(!tippedOver)
            waterParticle.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        else
            health.ChangeHealth(-pourRate * Time.deltaTime); 
    }

    private void sheDead(){
        popSound = GetComponentInChildren<AudioSource>();
        popSound.Play();
        Destroy(gameObject, popSound.clip.length);
    }
}