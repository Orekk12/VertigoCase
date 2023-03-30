using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WheelRotation : MonoBehaviour
{
    [SerializeField] private float minRotationAmount = 400;
    [SerializeField] private float maxRotationAmount = 800;
    [SerializeField] private float rotationDuration = 3f;
    [SerializeField] private GameObject wheel;

    private void Awake()
    {
        if (!wheel)
        {
            wheel = gameObject;
        }
    }

    private void StartRotation()
    {
        if (!wheel) return;
        
        var randomRotationAmount = UnityEngine.Random.Range(minRotationAmount, maxRotationAmount);
        wheel.transform.DORotate(new Vector3(0f, 0f, randomRotationAmount), rotationDuration)
            .SetRelative(true)
            .SetEase(Ease.OutQuad);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartRotation();
        }

        if (Input.GetKey(KeyCode.V))
        {
            Debug.Log(wheel.transform.localEulerAngles.z);
        }
    }
}
