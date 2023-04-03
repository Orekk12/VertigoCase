using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using Unity.Collections;
using DG.Tweening;

public class RewardHandler : MonoBehaviour
{
    [SerializeField] private Transform parentItemSlot;
    [SerializeField] private List<WheelSlotCard> wonCards;
    [SerializeField] private Image greenBackground;
    [SerializeField] private Image blueBackground;
    [SerializeField] private RectTransform zoneNumbers;

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
        MoveZoneCounter();
    }

    private void MoveZoneCounter()
    {
        var duration = 0.3f;
        blueBackground.transform.localScale = Vector3.one * 0.75f;
        blueBackground.enabled = true;
        zoneNumbers.DOAnchorPosX(zoneNumbers.anchoredPosition.x - 85f, duration)
            .OnComplete(() =>
            {
                
            });
        greenBackground.rectTransform.DOScale(Vector3.zero, duration);
        blueBackground.rectTransform.DOScale(Vector3.one * 0.75f, duration / 2)
            .OnComplete(() =>
            {
                blueBackground.rectTransform.DOScale(Vector3.one, duration / 2);
            });
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
