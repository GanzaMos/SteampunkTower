using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CanonFireController : MonoBehaviour
{
    [Space(5f)][Header("General settings")]
    [SerializeField] float shootTimePeriod = 2.0f; // Time period between shots in seconds

    [Space(5f)] [Header("VFX settings")]
    [SerializeField] ParticleSystem smokeVFX;
    
    Animator _animator;
    MuzzleFlashController _muzzleFlash;
    float _timeSinceLastShot = 0.0f;
    bool _isShooting = false;

    
    void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _muzzleFlash = GetComponentInChildren<MuzzleFlashController>();
        _timeSinceLastShot = shootTimePeriod;
    }


    void Update()
    {
        UpdateTimer();
        Shoot();
    }

    
    void UpdateTimer()
    {
        _timeSinceLastShot += Time.deltaTime;
    }

    
    void Shoot()
    {
        if (!(_isShooting && _timeSinceLastShot >= shootTimePeriod))
            return;
        
        _timeSinceLastShot = 0.0f;
        
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
