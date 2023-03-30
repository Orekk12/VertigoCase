using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotContentHandler : MonoBehaviour
{
    [SerializeField] private AllWheelSlotCards allSlotCards;

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
            contentFiller.FillSlotContent(allSlotCards.CardList[i].Image, allSlotCards.CardList[i].Amount);
        }
    }
}
