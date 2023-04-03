using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RewardMultiplier : MonoBehaviour
{
    [SerializeField] private float rewardIncreaseEverySpin = 0.1f;
    [SerializeField] private float superZoneMultiplier = 2f;

    //private float currentMultiplier = 0f;
    private CardHolder _cardHolder;

    private void Awake()
    {
        _cardHolder = GameObjectManager.Instance.CardHolder;
    }

    private void Start()
    {
        GameObjectManager.Instance.ZoneHandler.BeforeZoneChange += HandleRewardIncrease;
    }

    private void HandleRewardIncrease(int zoneCount)
    {
        var modifiedMultipler = 1f + (rewardIncreaseEverySpin * zoneCount-1);

        if (zoneCount  % 3 == 0)//super zone
        {
            modifiedMultipler *= 2f;
        }

        for (int i = 0; i < _cardHolder.SlotCardList.Count; i++)
        {
            _cardHolder.SlotCardList[i].amount = Mathf.FloorToInt(_cardHolder.SlotCardList[i].defaultAmount * modifiedMultipler);
        }
    }
}
