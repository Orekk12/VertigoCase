using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectManager : MonoBehaviour
{
    [SerializeField] private GameObject _wheel;
    public GameObject Wheel => _wheel;

    [SerializeField] private WheelRotation _wheelRotation;
    public WheelRotation WheelRotation => _wheelRotation;


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