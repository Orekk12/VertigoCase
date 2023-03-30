using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SlotCard")]
public class WheelSlotCard : ScriptableObject
{
    [SerializeField] private Sprite image;
    [SerializeField] private int amount;
}
