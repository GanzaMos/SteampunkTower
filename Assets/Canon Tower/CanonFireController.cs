using System;
using UnityEngine;
using UnityEngine.UI;

public class CanonFireController : MonoBehaviour
{
    public ParticleSystem smokeVFX;
    public float shootTimePeriod = 2.0f; // Time period between shots in seconds
    
    Animator _animator;
    MuzzleFlashController _muzzleFlash;
    float _timeSinceLastShot = 0.0f;
    bool _isShooting = false;

    void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _muzzleFlash = GetComponentInChildren<MuzzleFlashController>();
    }

    void Update()
    {
        UpdateTimer();
        
        if (_isShooting && _timeSinceLastShot >= shootTimePeriod)
        {
            Shoot();
            _timeSinceLastShot = 0.0f;
        }
    }

    void UpdateTimer()
    {
        _timeSinceLastShot += Time.deltaTime;
    }

    void Shoot()
    {
        if (_muzzleFlash != null)
            _muzzleFlash.ShootMuzzleFlash();
        
        if (smokeVFX != null)
            smokeVFX.Play();

        if (_animator != null)
            _animator.SetTrigger("Shoot");
    }

    public void ShootingSwitcher()
    {
        if (_isShooting)
            _isShooting = false;
        else
            _isShooting = true;
    }
}
