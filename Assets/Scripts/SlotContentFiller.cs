using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotContentFiller : MonoBehaviour
{
    private Image _slotImage;
    private TextMeshProUGUI _slotText;

    private void Awake()
    {
        _slotImage = transform.GetChild(0).GetComponent<Image>();
        _slotText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
    }

    public void FillSlotContent(Sprite slotImage, int slotAmount)
    {
        _slotImage.sprite = slotImage;

        if (slotAmount == 0)
        {
            _slotText.text = "";
        }
        else
        {
            _slotText.text = "x" + GetAmountAsText(slotAmount);
        }
    }

    private string GetAmountAsText(int number)
    {
        if (number < 1000)
            return number.ToString();
        
        var num = number / 1000.0f;
        return num.ToString("F1") + "K";
    }
}
