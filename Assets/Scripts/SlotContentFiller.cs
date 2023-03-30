using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class SlotContentFiller : MonoBehaviour
{
    private Image _slotImage;
    private TextMeshProUGUI _slotText;

    private void Awake()
    {
        _slotImage = transform.GetChild(0).GetComponent<Image>();
        _slotText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    public void FillSlotContent(Sprite slotImage, string slotText)
    {
        _slotImage.sprite = slotImage;
        _slotText.text = slotText;
    }
}
