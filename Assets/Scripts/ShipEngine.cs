using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShipEngine : MonoBehaviour
{
    [SerializeField] Animator anim;
    [Header("Audio")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip engineIdle;
    [SerializeField] AudioClip engineRun;
    

    public void PlayEngine()
    {
        if (anim.GetBool("IsShipMoving") == false)
        {
            anim.SetBool("IsShipMoving", true);
            audioSource.DOFade(0, 0.5f).OnComplete(ChangeClipToMoving);
        }
    }

    public void KillEngine()
    {
        if (anim.GetBool("IsShipMoving") == true) { 
            anim.SetBool("IsShipMoving", false);
            audioSource.DOFade(0, 0.5f).OnComplete(ChangeClipToIdle);
        }
    }

    private void ChangeClipToIdle()
    {
        audioSource.clip = engineIdle;
        audioSource.Play();
        audioSource.DOFade(1, 0.5f);
    }

    private void ChangeClipToMoving()
    {
        audioSource.clip = engineRun;
        audioSource.Play();
        audioSource.DOFade(1, 0.2f);
    }
}
