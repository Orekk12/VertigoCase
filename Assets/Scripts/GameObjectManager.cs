using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectManager : MonoBehaviour
{
    [SerializeField] private GameObject wheel;
    public GameObject Wheel => wheel;

    [SerializeField] private SpinButton spinButton;
    public SpinButton SpinButton => spinButton;

    [SerializeField] private WheelRotation wheelRotation;
    public WheelRotation WheelRotation => wheelRotation;

    [SerializeField] private WinCondition winCondition;
    public WinCondition WinCondition => winCondition;

    [SerializeField] private CardHolder cardHolder;
    public CardHolder CardHolder => cardHolder;

    [SerializeField] private SmoothDarkenPanel smoothDarkenPanel;
    public SmoothDarkenPanel SmoothDarkenPanel => smoothDarkenPanel;

    [SerializeField] private GameObject failPanel;
    public GameObject FailPanel => failPanel;

    [SerializeField] private ReviveCurrency reviveCurrency;
    public ReviveCurrency ReviveCurrency => reviveCurrency;

    [SerializeField] private ZoneHandler zoneHandler;
    public ZoneHandler ZoneHandler => zoneHandler;

    [SerializeField] private SlotContentHandler slotContentHandler;
    public SlotContentHandler SlotContentHandler => slotContentHandler;

    [SerializeField] private RewardHandler rewardHandler;
    public RewardHandler RewardHandler => rewardHandler;

    [SerializeField] private RewardMultiplier rewardMultiplier;
    public RewardMultiplier RewardMultiplier => rewardMultiplier;


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
        }
    }
    #endregion
}
