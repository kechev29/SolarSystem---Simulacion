using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TweenInfoPanel : MonoBehaviour
{
    [SerializeField] Image scrollInfoPanel;
    [SerializeField] Image scrollbarVertical;
    [SerializeField] Image scrollbarHandle;
    [SerializeField] Text panelText;

    public void PlayPanelOpen() {
        scrollInfoPanel.gameObject.SetActive(true);

        scrollInfoPanel.DOFade(0.4f, 0.3f);
        scrollbarVertical.DOFade(0.4f, 0.3f);
        scrollbarHandle.DOFade(1f, 0.3f);
        panelText.DOFade(1f, 0.3f);
    }

    public void PlayPanelClose()
    {
        scrollInfoPanel.DOFade(0f, 0.3f);
        scrollbarVertical.DOFade(0f, 0.3f);
        scrollbarHandle.DOFade(0f, 0.3f);
        panelText.DOFade(0f, 0.3f).OnComplete(DisableScrollPanel);
    }

    private void DisableScrollPanel()
    {
        scrollInfoPanel.gameObject.SetActive(false);
    }


}
