using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SmoothDarkenPanel : MonoBehaviour
{
    [SerializeField] private float endAlpha_value = 0.8f;
    [SerializeField] private float duration_value = 0.5f;

    private Image _panelImage;


    private void Awake()
    {
        _panelImage = GetComponent<Image>();
    }
    
    public void StartSmoothDarken()
    {
        _panelImage.DOFade(endAlpha_value, duration_value).SetEase(Ease.OutQuad);
        _panelImage.raycastTarget = true;
    }

    public void ReverseDarken()
    {
        _panelImage.DOFade(0, duration_value).SetEase(Ease.OutQuad);
        _panelImage.raycastTarget = false;
    }
}
