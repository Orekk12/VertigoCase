using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class ZoneHandler : MonoBehaviour
{
    [SerializeField] private Image greenBackground;
    [SerializeField] private Image blueBackground;
    [SerializeField] private RectTransform zoneNumbers;
    [SerializeField] private GameObject newNumberPrefab;

    private WinCondition _winCondition;
    private int zoneCount = 1;
    private bool leftSafeZone = false;

    private void Start()
    {
        _winCondition = GameObjectManager.Instance.WinCondition;
        if (_winCondition)
        {
            _winCondition.OnWinCard += MoveZoneOnWin;
            _winCondition.OnFailCard += MoveZoneCounter;
        }
    }

    private void OnDisable()
    {
        _winCondition.OnWinCard -= MoveZoneOnWin;
        _winCondition.OnFailCard -= MoveZoneCounter;
    }

    private void MoveZoneOnWin(WheelSlotCard tmp)
    {
        MoveZoneCounter();
    }

    private void MoveZoneCounter()
    {
        if ((zoneCount + 1) % 5 == 0)
        {
            SwitchColors(blueBackground, greenBackground);
            HandleSafeZone(true);
            leftSafeZone = true;
        }
        else
        {
            if (leftSafeZone)
            {
                leftSafeZone = false;
                HandleSafeZone(false);
            }
            SwitchColors(greenBackground, blueBackground);
        }
        
        zoneCount++;
        SpawnNewNumber();
    }

    private void SwitchColors(Image closingBg, Image openingBg)
    {
        var duration = 0.3f;
        openingBg.transform.localScale = Vector3.one * 0.75f;
        openingBg.enabled = true;
        zoneNumbers.DOAnchorPosX(zoneNumbers.anchoredPosition.x - 85f, duration);

        closingBg.rectTransform.DOScale(Vector3.zero, duration);
        openingBg.rectTransform.DOScale(Vector3.one * 0.75f, duration / 2)
            .OnComplete(() =>
            {
                openingBg.rectTransform.DOScale(Vector3.one, duration / 2);
            });
    }

    private void SpawnNewNumber()
    {
        var newNum = Instantiate(newNumberPrefab, zoneNumbers);
        var numTransform = newNum.GetComponent<RectTransform>();
        numTransform.anchoredPosition = new Vector2((4 + zoneCount) * 85, numTransform.anchoredPosition.y);
        newNum.GetComponent<TextMeshProUGUI>().text = (5 + zoneCount).ToString();
    }

    public void ResetZoneCounter()
    {
        zoneNumbers.DOAnchorPosX(0f, 0.5f);
        greenBackground.rectTransform.localScale = Vector3.one;
        blueBackground.enabled = false;
    }

    private void HandleSafeZone(bool isSafe)
    {
        var slotContentHandler = GameObjectManager.Instance.SlotContentHandler;
        var failIndex = slotContentHandler.GetFailCardIndex();
        var cardHolder = GameObjectManager.Instance.CardHolder;
        var lastIndex = cardHolder.ContentCardList.Count - 1;
        var cardToPut = cardHolder.ContentCardList[failIndex];
        if (isSafe)
        {
            cardToPut = cardHolder.ContentCardList[lastIndex];
        }

        slotContentHandler.SwitchSlotContentByIndex(failIndex, cardToPut);
    }
}
