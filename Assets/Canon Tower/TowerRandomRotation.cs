using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRandomRotation : MonoBehaviour
{
    [Space(5f)][Header("Rotation settings")]
    
    [SerializeField] Transform mount;
    [SerializeField] bool isRotationEnabled = true;
    [SerializeField] float minRotationTime = 1.0f;
    [SerializeField] float maxRotationTime = 5.0f;
    [SerializeField] float minTurnAngle = 15.0f;
    [SerializeField] float maxTurnAngle = 90.0f;
    [SerializeField] float rotationSpeed = 30f;

    enum RotationStatus
    {
        Rotating,
        Waiting
    }

    RotationStatus _rotationStatus = RotationStatus.Rotating;
    float _rotationTimer;
    float _nextTurnTime;
    Quaternion _targetRotation;
    

    void Start()
    {
        _targetRotation = mount.rotation;
        _nextTurnTime = Random.Range(minRotationTime, maxRotationTime);
    }


    void Update()
    {
        IdleRotation();
    }
    
    
    void IdleRotation()
    {
        if (!isRotationEnabled) return;
        
        if (_rotationStatus == RotationStatus.Rotating)
        {
            mount.rotation = Quaternion.RotateTowards(mount.rotation, _targetRotation, Time.deltaTime * rotationSpeed);

            if (Mathf.Approximately(mount.rotation.y, _targetRotation.y))
            {
                _rotationStatus = RotationStatus.Waiting;
            }
        }
        else if (_rotationStatus == RotationStatus.Waiting)
        {
            _rotationTimer += Time.deltaTime;

            if (_rotationTimer >= _nextTurnTime)
            {
                _rotationTimer = 0;
                _nextTurnTime = Random.Range(minRotationTime, maxRotationTime);
                _rotationStatus = RotationStatus.Rotating;
                SetRandomRotation();
            }
        }
    }
    
    void SetRandomRotation()
    {
        float randomAngle = Random.Range(minTurnAngle, maxTurnAngle);   // Calculate a random turn angle
        bool isClockwise = Random.Range(0, 2) == 0;                     // Determine the direction of rotation (clockwise or counterclockwise)

        // Apply the rotation to the target rotation
        if (isClockwise)
            SetTargetRotationAngle(randomAngle);
        else
            SetTargetRotationAngle(-randomAngle);
    }
    
    void SetTargetRotationAngle(float randomAngle)
    {
        _targetRotation *= Quaternion.Euler(0.0f, randomAngle, 0.0f);
    }
}
