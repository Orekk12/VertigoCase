using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CardHolder")]
public class CardHolder : ScriptableObject
{
    //slotCardList holds the cards that are placed in the game in order from slot1 to slot8
    [SerializeField] private List<WheelSlotCard> slotCardList;
    public List<WheelSlotCard> SlotCardList => slotCardList;

    //contentCardList hold the cards that can be assigned to slots, it holds possible content cards
    [SerializeField] private List<WheelSlotCard> contentCardList;
    public List<WheelSlotCard> ContentCardList => contentCardList;

    [SerializeField] private WheelSlotCard failCard;
    public WheelSlotCard FailCard => failCard;
}
