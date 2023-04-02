using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public Action<WheelSlotCard> OnWinCard;
    public Action OnFailCard;

    private Transform _wheelTransform;
    private WheelRotation _wheelRotation;
    private CardHolder _cardHolder;
    private SpinButton _spinButton;

    private void Start()
    {
        _wheelRotation = GameObjectManager.Instance.WheelRotation;
        _wheelTransform = GameObjectManager.Instance.Wheel.transform;
        _cardHolder = GameObjectManager.Instance.CardHolder;
        _spinButton = GameObjectManager.Instance.SpinButton;

        if (_wheelRotation)
        {
            _wheelRotation.OnSpinEnd += CheckWheelReward;
        }
    }

    private void OnDisable()
    {
        _wheelRotation.OnSpinEnd -= CheckWheelReward;
        OnWinCard = null;
        OnFailCard = null;
    }

    private void CheckWheelReward()
    {
        if (!_wheelTransform) return;

        //Debug.Log("rotation: "+ wheelTransform.eulerAngles.z);
        //Debug.Log("Index: " + GetRewardIndex(wheelTransform.eulerAngles.z));
        var resultIndex = GetRewardIndex(_wheelTransform.eulerAngles.z);
        var slotCard = GetSlotCard(resultIndex);

        if (slotCard.isFail)
        {
            OnFailCard?.Invoke();
        }
        else
        {
            OnWinCard?.Invoke(slotCard);
        }

        _wheelRotation.ResetWheelRotation();
        _spinButton.EnableButton();
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
        return _cardHolder.SlotCardList[i];
    }
}
