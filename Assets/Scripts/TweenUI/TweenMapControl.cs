using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TweenMapControl : MonoBehaviour
{
    [SerializeField] RectTransform mapBG;
    [SerializeField] Image planetsImage;
    [SerializeField] GameObject planetButtons;
    [SerializeField] GameObject crosshairs;

    [System.NonSerialized] public GameObject parentCanvas;
    Sequence openMapBg;

    public void PlayBGEnable()
    {
        openMapBg = DOTween.Sequence();

        openMapBg.Append(mapBG.DOScaleX(1, 0.25f)).
            Append(mapBG.DOScaleY(1, 0.25f));

        openMapBg.OnComplete(TurnOnPlanets);
    }

    public void PlayBGDisable()
    {
        DisablePlanetButtons();

        planetsImage.DOFade(0f, 0.25f).OnComplete(TurnOffBG);
        
    }

    private void TurnOnPlanets()
    {
        planetsImage.gameObject.SetActive(true);
        planetsImage.DOFade(1f, 0.5f).OnComplete(EnablePlanetButtons);
    }

    private void EnablePlanetButtons()
    {
        planetButtons.SetActive(true);
        crosshairs.SetActive(true);
    }

    private void DisablePlanetButtons()
    {
        planetButtons.SetActive(false);
        crosshairs.SetActive(false);
    }

    private void TurnOffBG()
    {
        planetsImage.gameObject.SetActive(false);

        Sequence closeMapBg = DOTween.Sequence();

        closeMapBg.Append(mapBG.DOScaleY(0.05f, 0.25f)).
            Append(mapBG.DOScaleX(0, 0.25f));

        closeMapBg.OnComplete(TurnOffCanvas);
    }

    private void TurnOffCanvas()
    {
        parentCanvas.SetActive(false);
    }

}
