using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CreditsToggle : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] Image creditsImage;

    Image ownIcon;

    private void Start()
    {
        ownIcon = GetComponent<Image>();
    }


    public void ShowCredits()
    {
        ownIcon.DOFade(0.5f, 0.5f);
        canvas.SetActive(true);
        creditsImage.DOFade(1f, 0.25f);
    }

    public void HideCredits()
    {
        ownIcon.DOFade(0.2f, 0.5f);
        creditsImage.DOFade(0f, 0.25f).OnComplete(DisableCanvas);
    }

    private void DisableCanvas()
    {
        canvas.SetActive(false);
    }

}
