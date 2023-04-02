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
    private CardHolder cardHolder;

    private void Start()
    {
        wheelRotation = GameObjectManager.Instance.WheelRotation;
        wheelTransform = GameObjectManager.Instance.Wheel.transform;
        cardHolder = GameObjectManager.Instance.CardHolder;

        if (wheelRotation)
        {
            wheelRotation.OnSpinEnd += CheckWheelReward;
        }
    }

    private void OnDisable()
    {
        wheelRotation.OnSpinEnd -= CheckWheelReward;
        OnWinCard = null;
        OnFailCard = null;
    }

    private void CheckWheelReward()
    {
        if (!wheelTransform) return;

        //Debug.Log("rotation: "+ wheelTransform.eulerAngles.z);
        //Debug.Log("Index: " + GetRewardIndex(wheelTransform.eulerAngles.z));
        var resultIndex = GetRewardIndex(wheelTransform.eulerAngles.z);
        var slotCard = GetSlotCard(resultIndex);

        if (slotCard.isFail)
        {
            OnFailCard?.Invoke();
        }
        else
        {
            OnWinCard?.Invoke(slotCard);
        }

        wheelRotation.ResetWheelRotation();
    }

    private int GetRewardIndex(float rotation)
    {
        var tmpRot = rotation - 22.5;
        var index = Math.Ceiling(tmpRot / 45);
        if (index == 8) index = 0;
        return (int)index;
    }

    private WheelSlotCard GetSlotCard(int i)
    {
        return cardHolder.SlotCardList[i];
    }
}
