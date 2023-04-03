using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ZoneUIChanges : MonoBehaviour
{
    [SerializeField] private RewardMultiplier rewardMultiplier;
    
    [SerializeField] private Image frame;
    [SerializeField] private Sprite goldenFrame;
    [SerializeField] private Sprite silverFrame;
    
    [SerializeField] private Image arrow;
    [SerializeField] private Sprite goldenArrow;
    [SerializeField] private Sprite silverArrow;
    
    [SerializeField] private Image wheel;
    [SerializeField] private Sprite goldenWheel;
    [SerializeField] private Sprite silverWheel;

    [SerializeField] private TextMeshProUGUI altText;
    [SerializeField] private TextMeshProUGUI titleText;

    [SerializeField] private Color goldenColor;
    [SerializeField] private Color silverColor;

    private void Start()
    {
        if (rewardMultiplier)
        {
            rewardMultiplier.OnRewardMultiplierChange += SwitchUI;
        }
        
        SwitchUI(1f, false);
    }

    public void SwitchUI(float multiplier, bool isGolden)
    {
        if (isGolden)
        {
            frame.sprite = goldenFrame;
            arrow.sprite = goldenArrow;
            wheel.sprite = goldenWheel;
            titleText.color = goldenColor;
            altText.color = goldenColor;
            titleText.text = "GOLDEN SPIN";
        }
        else
        {
            frame.sprite = silverFrame;
            arrow.sprite = silverArrow;
            wheel.sprite = silverWheel;
            titleText.color = silverColor;
            altText.color = silverColor;
            titleText.text = "SILVER SPIN";
        }
        altText.text = "x" + multiplier + " Rewards";
    }
}
