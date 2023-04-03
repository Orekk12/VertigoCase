using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReviveCurrency : MonoBehaviour
{
    [SerializeField] private int reviveCost_value = 50;
    [SerializeField] private int initialCurrencyAmount_value = 100;
    [SerializeField] private int currentCurrencyAmount_value = 100;
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
        currentCurrencyAmount_value += i;
        SetCurrencyUI();
    }
    
    public bool UseCurrency(int i)
    {
        var tmpCurrency = currentCurrencyAmount_value;
        tmpCurrency -= i;
        if (tmpCurrency >= 0)
        {
            currentCurrencyAmount_value = tmpCurrency;
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
        currentCurrencyAmount_value = initialCurrencyAmount_value;
        SetCurrencyUI();
    }

    private void SetCurrencyUI()
    {
        currencyText.text = GetAmountAsText(currentCurrencyAmount_value);
    }

    private void SetCostUI()
    {
        var costText = button.transform.GetChild(2);
        if (costText)
        {
            costText.GetComponent<TextMeshProUGUI>().text = reviveCost_value.ToString();
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
        if (UseCurrency(reviveCost_value))
        {
            InterfaceController.SmoothDisappear(GameObjectManager.Instance.FailPanel, 0.5f);
            GameObjectManager.Instance.SmoothDarkenPanel.ReverseDarken();
        }
    }
}
