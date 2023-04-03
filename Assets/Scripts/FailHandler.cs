using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FailHandler : MonoBehaviour
{
    [SerializeField] private Button giveupButton;
    private WinCondition _winCondition;
    private SmoothDarkenPanel _smoothDarkenPanel;
    private GameObject _failPanel;

    private void Awake()
    {
        _winCondition = GameObjectManager.Instance.WinCondition;
        _smoothDarkenPanel = GameObjectManager.Instance.SmoothDarkenPanel;
        _failPanel = GameObjectManager.Instance.FailPanel;
    }

    private void Start()
    {
        _winCondition.OnFailCard += HandleFail;
        if (giveupButton) giveupButton.onClick.AddListener(HandleGiveUpButton);
    }

    private void OnDisable()
    {
        _winCondition.OnFailCard -= HandleFail;
        giveupButton.onClick.RemoveAllListeners();
    }

    private void HandleFail()
    {
        Debug.Log("Fail!");
        _smoothDarkenPanel.StartSmoothDarken();
        InterfaceController.SmoothAppear(_failPanel, Vector3.one, 0.5f);
    }

    private void HandleGiveUpButton()
    {
        InterfaceController.SmoothDisappear(GameObjectManager.Instance.FailPanel, 0.5f);
        GameObjectManager.Instance.SmoothDarkenPanel.ReverseDarken();
    }
}
