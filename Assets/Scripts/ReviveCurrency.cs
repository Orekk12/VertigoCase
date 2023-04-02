using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviveCurrency : MonoBehaviour
{
    [SerializeField] private int initialCurrencyAmount = 100;
    [SerializeField] private int currentCurrencyAmount = 100;

    private void Start()
    {
        currentCurrencyAmount = initialCurrencyAmount;
    }

    public void AddCurrency(int i)
    {
        currentCurrencyAmount += i;
    }
    
    public void UseCurrency(int i)
    {
        currentCurrencyAmount -= i;
    }

    public void ResetCurrency()
    {
        currentCurrencyAmount = initialCurrencyAmount;
    }
}
