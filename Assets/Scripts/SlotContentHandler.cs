using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotContentHandler : MonoBehaviour
{
    private CardHolder _cardHolder;

    private void Awake()
    {
        _cardHolder = GameObjectManager.Instance.CardHolder;
    }

    private void Start()
    {
        SetSlotContents();
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
            }
            CopyCardContents(_cardHolder.SlotCardList[i], _cardHolder.ContentCardList[i]);
            contentFiller.FillSlotContent(_cardHolder.ContentCardList[i].image, _cardHolder.ContentCardList[i].amount);
        }
    }

    public void CopyCardContents(WheelSlotCard slotCard, WheelSlotCard contentCard)
    {
        slotCard.image = contentCard.image;
        slotCard.amount = contentCard.amount;
        slotCard.isFail = contentCard.isFail;
    }
}
