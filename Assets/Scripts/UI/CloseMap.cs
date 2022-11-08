using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseMap : MonoBehaviour
{
    Animator parentAnim;

    private void Awake()
    {
        parentAnim = transform.parent.gameObject.GetComponent<Animator>();
    }


    public void TriggerMapAnimation()
    {
        parentAnim.SetBool("Open", false);
    }

    public void TriggerPlanetsAnimation()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }


}
