using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SmoothDarkenPanel : MonoBehaviour
{
    [SerializeField] private float endAlpha;
    [SerializeField] private float duration;

    private Image _panelImage;


    private void Awake()
    {
        _panelImage = GetComponent<Image>();
    }

    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.F))
        {
            StartSmoothDarken();
        }*/
    }

    public void StartSmoothDarken()
    {
        _panelImage.DOFade(endAlpha, duration).SetEase(Ease.OutQuad);
    }
}
