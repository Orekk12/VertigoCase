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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            CheckWheelReward();
        }
    }

    private void CheckWheelReward()
    {
        if (!wheelTransform) return;

        var index = wheelTransform.eulerAngles.z / 22.5;
        Debug.Log(wheelTransform.eulerAngles.z + " " + index);

        wheelRotation.ResetWheelRotation();
    }
}
