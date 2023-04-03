using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using Unity.Collections;

public class RewardHandler : MonoBehaviour
{
    [SerializeField] private Transform parentItemSlot;
    [SerializeField] private List<WheelSlotCard> wonCards;
    [SerializeField] private GameObject rewardSlotPosObject;

    private Dictionary<string, int> wonCardsDict = new Dictionary<string, int>();
    private WinCondition _winCondition;
    private int activeSlotCount = 0;

    private void Start()
    {
        _winCondition = GameObjectManager.Instance.WinCondition;
        if (_winCondition)
        {
            _winCondition.OnWinCard += HandleCardWin;
        }
        activeSlotCount = 0;
    }

    private void OnDisable()
    {
        _winCondition.OnWinCard -= HandleCardWin;
    }

    private void HandleCardWin(WheelSlotCard slotCard)
    {
        if (wonCardsDict.ContainsKey(slotCard.image.name))
        {
            wonCardsDict.TryGetValue(slotCard.image.name, out var index);
            var rewardChildItem = parentItemSlot.GetChild(index);
            var rewardChildText = rewardChildItem.GetComponentInChildren<TextMeshProUGUI>();
            rewardChildText.text = GetAmountAsText(slotCard.amount + GetAmountAsInt(rewardChildText.text));
        }
        else
        {
            var rewardChildItem = parentItemSlot.GetChild(activeSlotCount);
            var rewardChildImage = rewardChildItem.GetComponentInChildren<Image>();
            rewardChildImage.sprite = slotCard.image;
            rewardChildImage.enabled = true;
            var rewardChildText = rewardChildItem.GetComponentInChildren<TextMeshProUGUI>();
            rewardChildText.text = GetAmountAsText(slotCard.amount);
            rewardChildText.enabled = true;
            wonCardsDict.TryAdd(slotCard.image.name, activeSlotCount);
            activeSlotCount++;
        }
        wonCards.Add(slotCard);
    }

    private string GetAmountAsText(int number)
    {
        return "x" + number.ToString();
    }

    private int GetAmountAsInt(string s)
    {
        return Convert.ToInt32(s[1..]);
    }
}
