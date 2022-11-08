using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapAnimator : MonoBehaviour
{
    [SerializeField] GameObject mapBG;
    TweenMapControl mapTween;
    Animator mapBGAnim;
    Animator mapBGChildAnim;
    GameObject mapCanvas;

    private void Awake()
    {
        //mapBGAnim = mapBG.GetComponent<Animator>();
        mapTween = GetComponent<TweenMapControl>();
        

        //mapBGChildAnim = mapBG.transform.GetChild(0).gameObject.GetComponent<Animator>();
        mapCanvas = mapBG.transform.parent.gameObject;

        mapTween.parentCanvas = mapCanvas;
    }

    public void OpenMap()
    {
        if(mapCanvas != null)
        {
            if (!mapCanvas.activeSelf)
            {
                mapCanvas.SetActive(true);
                mapTween.PlayBGEnable();
            } else
            {
                mapTween.PlayBGDisable();
            }
            

            

            //CheckAnimationToPlay();
        }
    }

    private void CheckAnimationToPlay()
    {
        if (mapBGAnim.GetBool("Open"))
        {
            mapBGChildAnim.SetBool("FadePlanets", true);
        } else
        {
            mapBGAnim.SetBool("Open", true);
        }

    }


}

