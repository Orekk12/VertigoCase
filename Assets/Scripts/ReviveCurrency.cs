using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReviveCurrency : MonoBehaviour
{
    [SerializeField] private int reviveCost = 100;
    [SerializeField] private int initialCurrencyAmount = 100;
    [SerializeField] private int currentCurrencyAmount = 100;
    [SerializeField] private TextMeshProUGUI currencyText;
    [SerializeField] private Button button;

    private void Start()
    {
        ResetCurrency();
        if (button)
        {
            button.onClick.AddListener(ClickButton);
            SetCostUI();
        }
        else
        {
            Debug.LogError("Button reference is missing!");
        }
    }
    
    private void OnDisable()
    {
        button.onClick.RemoveAllListeners();
    }

    public void AddCurrency(int i)
    {
        currentCurrencyAmount += i;
        SetCurrencyUI();
    }
    
    public bool UseCurrency(int i)
    {
        var tmpCurrency = currentCurrencyAmount;
        tmpCurrency -= i;
        if (tmpCurrency >= 0)
        {
            currentCurrencyAmount = tmpCurrency;
            SetCurrencyUI();
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ResetCurrency()
    {
        currentCurrencyAmount = initialCurrencyAmount;
        SetCurrencyUI();
    }

    private void SetCurrencyUI()
    {
        currencyText.text = GetAmountAsText(currentCurrencyAmount);
    }

    private void SetCostUI()
    {
        var costText = button.transform.GetChild(2);
        if (costText)
        {
            costText.GetComponent<TextMeshProUGUI>().text = reviveCost.ToString();
        }
        else
        {
            Debug.LogError("Could not find the revive cost text!");
        }
    }
    
    private string GetAmountAsText(int number)
    {
        if (number < 1000)
            return "x" + number.ToString();
        
        var num = number / 1000.0f;
        return "x" + num.ToString("F1") + "K";
    }
    
    private void ClickButton()
    {
        if (UseCurrency(reviveCost))
        {
            InterfaceController.SmoothDisappear(GameObjectManager.Instance.FailPanel, 0.5f);
            GameObjectManager.Instance.SmoothDarkenPanel.ReverseDarken();
        }
    }
}
