using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WheelRotation : MonoBehaviour
{
    public Action OnSpinEnd;

    [SerializeField] private float minRotationAmount = 400;
    [SerializeField] private float maxRotationAmount = 800;
    [SerializeField] private float rotationDuration = 3f;

    private bool canSpin = true;

    public void ResetWheelRotation()
    {
        canSpin = true;
    }

    public void StartRotation()
    {
        if (!canSpin) return;

        canSpin = false;
        var randomRotationAmount = UnityEngine.Random.Range(minRotationAmount, maxRotationAmount);
        gameObject.transform.DORotate(new Vector3(0f, 0f, randomRotationAmount), rotationDuration)
            .SetRelative(true)
            .SetEase(Ease.OutQuad)
            .OnComplete(()=> { OnSpinEnd?.Invoke(); });
    }
}
