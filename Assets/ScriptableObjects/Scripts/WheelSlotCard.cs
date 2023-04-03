using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SlotCard")]
public class WheelSlotCard : ScriptableObject
{
    [SerializeField] public Sprite image;
    //public Sprite Image => image;

    [SerializeField] public int amount;
    //public int Amount => amount;

    [SerializeField] public int defaultAmount;

    [SerializeField] public bool isFail;
    //public bool isFail => isFail;
}
