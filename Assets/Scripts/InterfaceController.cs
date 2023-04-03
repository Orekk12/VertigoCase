using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

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
    
    public static void SmoothDisappear(GameObject uiObject, float disappearDuration)
    {
        uiObject.transform.DOScale(Vector3.zero, disappearDuration)
            .OnComplete(()=>
            {
                uiObject.SetActive(false);
            });
    }
}
