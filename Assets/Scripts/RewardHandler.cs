using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;

public class RewardHandler : MonoBehaviour
{
    [SerializeField] private List<WheelSlotCard> wonCards;

    private WinCondition _winCondition;

    private void Start()
    {
        _winCondition = GameObjectManager.Instance.WinCondition;
        if (_winCondition)
        {
            _winCondition.OnWinCard += HandleCardWin;
        }
    }

    private void OnDisable()
    {
        _winCondition.OnWinCard -= HandleCardWin;
    }

    private void HandleCardWin(WheelSlotCard slotCard)
    {
        wonCards.Add(slotCard);
    }
}
