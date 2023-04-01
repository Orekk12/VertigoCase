using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public Action<WheelSlotCard> OnWinCard;
    public Action OnFailCard;

    private Transform wheelTransform;
    private WheelRotation wheelRotation;
    private AllWheelSlotCards allWheelSlotCards;

    private void Start()
    {
        wheelRotation = GameObjectManager.Instance.WheelRotation;
        wheelTransform = GameObjectManager.Instance.Wheel.transform;
        allWheelSlotCards = GameObjectManager.Instance.AllWheelSlotCards;

        if (wheelRotation)
        {
            wheelRotation.OnSpinEnd += CheckWheelReward;
        }
    }

    private void OnDisable()
    {
        wheelRotation.OnSpinEnd -= CheckWheelReward;
    }

    private void CheckWheelReward()
    {
        if (!wheelTransform) return;

        //Debug.Log("rotation: "+ wheelTransform.eulerAngles.z);
        //Debug.Log("Index: " + GetRewardIndex(wheelTransform.eulerAngles.z));
        var resultIndex = GetRewardIndex(wheelTransform.eulerAngles.z);
        var slotCard = GetSlotCard(resultIndex);

        if (slotCard.IsFail)
        {
            OnFailCard?.Invoke();
        }
        else
        {
            OnWinCard?.Invoke(slotCard);
        }
    }

    private int GetRewardIndex(float rotation)
    {
        var tmpRot = rotation - 22.5;
        var index = Math.Ceiling(tmpRot / 45);
        if (index == 8) index = 1;
        return (int)index - 1;
    }

    private WheelSlotCard GetSlotCard(int i)
    {
        return allWheelSlotCards.CardList[i];
    }
}
