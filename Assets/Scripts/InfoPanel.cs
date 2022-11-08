using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InfoPanel : MonoBehaviour
{
    //[SerializeField] TextMeshProUGUI textComponent;
    [SerializeField] Text textComponent;

    TweenInfoPanel tweenPanel;
    Animator anim;

    void Awake()
    {
        ShipEvents.arrivalAtTargetName += UpdatePanel;
        ShipEvents.arrivalAtTarget += OpenPanel;
        ShipEvents.leavingTarget += ClosePanel;

        //anim = GetComponent<Animator>();
        tweenPanel = GetComponent<TweenInfoPanel>();
    }

    private void UpdatePanel(string newInfo)
    {
        textComponent.text = newInfo;
    }

    private void OpenPanel()
    {
        tweenPanel.PlayPanelOpen();

        //anim.SetBool("OpenPanel", true);
    }

    private void ClosePanel()
    {
        tweenPanel.PlayPanelClose();

        //anim.SetBool("OpenPanel", false);
    }

    private void OnDestroy()
    {
        ShipEvents.arrivalAtTargetName -= UpdatePanel;
        ShipEvents.arrivalAtTarget -= OpenPanel;
        ShipEvents.leavingTarget -= ClosePanel;
    }
}
