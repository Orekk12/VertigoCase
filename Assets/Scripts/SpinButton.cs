using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpinButton : MonoBehaviour
{
    private WheelRotation _wheelRotation;
    private Button _spinButton;

    private void Awake()
    {
        _spinButton = GetComponent<Button>();
        _wheelRotation = GameObjectManager.Instance.WheelRotation;
    }

    private void Start()
    {
        if (_spinButton && _wheelRotation)
        {
            _spinButton.onClick.AddListener(_wheelRotation.StartRotation);
            _spinButton.onClick.AddListener(DisableButton);
        }
    }

    private void OnDisable()
    {
        _spinButton.onClick.RemoveAllListeners();
    }

    public void EnableButton()
    {
        _spinButton.interactable = true;
    }

    private void DisableButton()
    {
        _spinButton.interactable = false;
    }
}
