using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlashController : MonoBehaviour
{
    ParticleSystem muzzleFlashVFX1;
    [SerializeField] ParticleSystem muzzleFlashVFX2;
    [SerializeField] ParticleSystem muzzleFlashVFX3;
    [SerializeField] ParticleSystem muzzleFlashVFX4;
    [SerializeField] ParticleSystem muzzleFlashVFX5;
    [SerializeField] ParticleSystem muzzleFlashVFX6;
    [SerializeField] Light muzzleFlashLight;
    
    float _lightDuration = 0.05f;
    float _timer = 0.0f;
    bool _isLightOn = false;

    
    void Start()
    {
        muzzleFlashVFX1 = GetComponent<ParticleSystem>();
    }
    
    
    void Update()
    {
        if (_isLightOn)
        {
            _timer += Time.deltaTime;
            
            if (_timer >= _lightDuration)
            {
                // Turn off the light
                muzzleFlashLight.enabled = false;
                _isLightOn = false;
                _timer = 0.0f; // Reset the timer
            }
        }
    }
    
    
    public void ShootMuzzleFlash()
    {
        muzzleFlashVFX1.Play();
        muzzleFlashVFX2.Play();
        muzzleFlashVFX3.Play();
        muzzleFlashVFX4.Play();
        muzzleFlashVFX5.Play();
        muzzleFlashVFX6.Play();
        PlayMuzzleFlashLight();
    }
    
    
    void PlayMuzzleFlashLight()
    {
        muzzleFlashLight.enabled = true;
        _isLightOn = true;
    }
}
