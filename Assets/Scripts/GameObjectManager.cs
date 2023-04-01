using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectManager : MonoBehaviour
{
    [SerializeField] private GameObject wheel;
    public GameObject Wheel => wheel;

    [SerializeField] private WheelRotation wheelRotation;
    public WheelRotation WheelRotation => wheelRotation;

    [SerializeField] private WinCondition winCondition;
    public WinCondition WinCondition => winCondition;

    [SerializeField] private AllWheelSlotCards allWheelSlotCards;
    public AllWheelSlotCards AllWheelSlotCards => allWheelSlotCards;


    #region SINGLETON PATTERN
    private static GameObjectManager _instance;
    public static GameObjectManager Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            //DontDestroyOnLoad(this.gameObject);
        }
    }
    #endregion
}
