using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RewardMultiplier : MonoBehaviour
{
    public Action<float, bool> OnRewardMultiplierChange;
    [SerializeField] private float rewardIncreaseEverySpin = 0.1f;

    private CardHolder _cardHolder;

    private void Awake()
    {
        _cardHolder = GameObjectManager.Instance.CardHolder;
    }

    private void Start()
    {
        GameObjectManager.Instance.WinCondition.OnSelectRewardCard += HandleRewardIncrease;
        GameObjectManager.Instance.ZoneHandler.OnZoneReset += ResetRewards;
    }

    private void OnDisable()
    {
        GameObjectManager.Instance.WinCondition.OnSelectRewardCard -= HandleRewardIncrease;
        GameObjectManager.Instance.ZoneHandler.OnZoneReset -= ResetRewards;
    }

    private void HandleRewardIncrease()
    {
        var zoneCount = GameObjectManager.Instance.ZoneHandler.GetZoneCount();
        var modifiedMultipler = 1f + (rewardIncreaseEverySpin * zoneCount);
        bool isSuper = false;
        if (zoneCount  % 7 == 0)//super zone
        {
            modifiedMultipler *= 2f;
            isSuper = true;
        }
        
        OnRewardMultiplierChange?.Invoke(modifiedMultipler, isSuper);

        for (int i = 0; i < _cardHolder.SlotCardList.Count; i++)
        {
            _cardHolder.SlotCardList[i].amount = Mathf.CeilToInt(_cardHolder.SlotCardList[i].defaultAmount * modifiedMultipler);
        }
    }

    private void ResetRewards()
    {
        OnRewardMultiplierChange?.Invoke(1f, false);
        for (int i = 0; i < _cardHolder.SlotCardList.Count; i++)
        {
            _cardHolder.SlotCardList[i].amount = _cardHolder.SlotCardList[i].defaultAmount;
        }
    }
}
