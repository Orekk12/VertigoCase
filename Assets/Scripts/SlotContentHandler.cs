using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SlotContentHandler : MonoBehaviour
{
    private CardHolder _cardHolder;
    private int failCardIndex = -1;

    private void Awake()
    {
        _cardHolder = GameObjectManager.Instance.CardHolder;
    }

    private void Start()
    {
        SetSlotContents();
        //GameObjectManager.Instance.WinCondition.OnSelectRewardCard += RefreshSlotContents;
        GameObjectManager.Instance.WheelRotation.OnSpinEnd += RefreshSlotContents;
        GameObjectManager.Instance.ZoneHandler.OnZoneReset += RefreshSlotContents;
    }

    private void SetSlotContents()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var childSlotTransform = transform.GetChild(i);
            var contentFiller = childSlotTransform.GetComponent<SlotContentFiller>();
            if (_cardHolder.ContentCardList[i].isFail)
            {
                //Increase the size of the image to fit the fail card in the slot.
                childSlotTransform.GetChild(0).localScale *= 1.7f;
                failCardIndex = i;
            }
            CopyCardContents(_cardHolder.SlotCardList[i], _cardHolder.ContentCardList[i]);
            contentFiller.FillSlotContent(_cardHolder.ContentCardList[i].image, _cardHolder.ContentCardList[i].amount);
        }
    }

    private void RefreshSlotContents()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var childSlotTransform = transform.GetChild(i);
            var contentFiller = childSlotTransform.GetComponent<SlotContentFiller>();
            contentFiller.FillSlotContent(_cardHolder.SlotCardList[i].image, _cardHolder.SlotCardList[i].amount);
        }
    }

    public void SwitchSlotContentByIndex(int i, WheelSlotCard slotCard)
    {
        var childSlotTransform = transform.GetChild(i);
        var contentFiller = childSlotTransform.GetComponent<SlotContentFiller>();
        if (slotCard.isFail)
        {
            childSlotTransform.GetChild(0).localScale *= 1.7f;
            failCardIndex = i;
        }
        else
        {
            childSlotTransform.GetChild(0).localScale /= 1.7f;
        }
        CopyCardContents(_cardHolder.SlotCardList[i], slotCard);
        contentFiller.FillSlotContent(slotCard.image, slotCard.amount);
    }

    public void CopyCardContents(WheelSlotCard slotCard, WheelSlotCard contentCard)
    {
        slotCard.image = contentCard.image;
        slotCard.amount = contentCard.amount;
        slotCard.isFail = contentCard.isFail;
        slotCard.defaultAmount = contentCard.defaultAmount;
    }

    public int GetFailCardIndex()
    {
        return failCardIndex;
    }

    public List<WheelSlotCard> Shuffle(List<WheelSlotCard> list)
    {
        var r = new System.Random();
        return list.OrderBy(x => r.Next()).ToList();
    }
}
