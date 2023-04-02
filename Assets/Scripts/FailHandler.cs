using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailHandler : MonoBehaviour
{
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
    }

    private void OnDisable()
    {
        _winCondition.OnFailCard -= HandleFail;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            HandleFail();
        }
    }

    private void HandleFail()
    {
        Debug.Log("Fail!");
        _smoothDarkenPanel.StartSmoothDarken();
        InterfaceController.SmoothAppear(_failPanel, Vector3.one, 0.5f);
    }
}
