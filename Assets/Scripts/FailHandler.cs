using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailHandler : MonoBehaviour
{
    private WinCondition _winCondition;

    private void Awake()
    {
        _winCondition = GameObjectManager.Instance.WinCondition;
    }

    private void Start()
    {
        _winCondition.OnFailCard += HandleFail;
    }

    private void OnDisable()
    {
        _winCondition.OnFailCard -= HandleFail;

    }

    private void HandleFail()
    {
        Debug.Log("Fail1");
    }
}
