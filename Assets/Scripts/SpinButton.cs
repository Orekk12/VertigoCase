using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpinButton : MonoBehaviour
{
    private WheelRotation wheelRotation;
    private Button spinButton;

    private void Awake()
    {
        spinButton = GetComponent<Button>();
        wheelRotation = GameObjectManager.Instance.WheelRotation;

        if (spinButton && wheelRotation)
        {
            spinButton.onClick.AddListener(()=> wheelRotation.StartRotation());
        }
    }

    private void OnDisable()
    {
        spinButton.onClick.RemoveAllListeners();
    }
}
