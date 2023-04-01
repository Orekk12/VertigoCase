using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    private Transform wheelTransform;
    private WheelRotation wheelRotation;

    private void Start()
    {
        wheelRotation = GameObjectManager.Instance.WheelRotation;
        wheelTransform = GameObjectManager.Instance.Wheel.transform;

        if (wheelRotation)
        {
            wheelRotation.OnSpinEnd += CheckWheelReward;
        }
    }

    private void CheckWheelReward()
    {
        if (!wheelTransform) return;

        Debug.Log("rotation: "+ wheelTransform.eulerAngles.z);
        Debug.Log("Index: " + GetRewardIndex(wheelTransform.eulerAngles.z));

        wheelRotation.ResetWheelRotation();
    }

    private int GetRewardIndex(float rotation)
    {
        var tmpRot = rotation - 22.5;
        var index = Math.Ceiling(tmpRot / 45);
        if (index == 8) index = 0;
        return (int)index;
    }
}
