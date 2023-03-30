using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SlotCardHolder")]
public class AllWheelSlotCards : ScriptableObject
{
    [SerializeField] private List<WheelSlotCard> cardList;
    public List<WheelSlotCard> CardList => cardList;
}
