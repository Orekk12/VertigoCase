using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    [SerializeField] private Transform wheelTransform;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            CheckWheelReward();
        }
    }

    public void CheckWheelReward()
    {
        var index = wheelTransform.eulerAngles.z / 22.5;
        Debug.Log(wheelTransform.eulerAngles.z + " " + index);
    }
}
