using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public string tipToShow;
    private float timeToWait = 0.5f;

    public void OnPointerEnter(PointerEventData eventData)
    {
        // stops other tips, starts timer before this tip shows
        StopAllCoroutines();
        StartCoroutine(StartTimer());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // stops the last tip
        StopAllCoroutines();
        HoverTipManager.OnMouseMiss();
    }

    private void showTip()
    {
        // displays the tip
        HoverTipManager.OnMouseHover(tipToShow, Input.mousePosition);
    }

    private IEnumerator StartTimer()
    {
        // runs the timer before displaying the tip
        yield return new WaitForSeconds(timeToWait);
        showTip();
    }
}
