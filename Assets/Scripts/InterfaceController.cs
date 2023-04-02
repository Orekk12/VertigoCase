using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEditor.U2D.Path;
using UnityEngine;

public class InterfaceController : MonoBehaviour
{
    public static void EnableUIObject(GameObject uiObject)
    {
        uiObject.SetActive(true);
    }

    public static void SmoothAppear(GameObject uiObject, Vector3 targetScale, float appearDuration)
    {
        uiObject.transform.localScale = Vector3.zero;
        uiObject.SetActive(true);
        
        uiObject.transform.DOScale(targetScale, appearDuration);
    }
}
