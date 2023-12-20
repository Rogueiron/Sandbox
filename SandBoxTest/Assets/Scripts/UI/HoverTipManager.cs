using System;
using TMPro;
using UnityEngine;

public class HoverTipManager : MonoBehaviour
{

    public TextMeshProUGUI tipText;
    public RectTransform tipWindow;

    public static Action<string, Vector2> OnMouseHover;
    public static Action OnMouseMiss;

    private void OnEnable()
    {
        // turns on tip
        OnMouseHover += ShowTip;
        OnMouseMiss += HideTip;
    }

    private void OnDisable()
    {
        // turns off tip
        OnMouseHover -= ShowTip;
        OnMouseMiss -= HideTip;
    }

    void Start()
    {
        // tip dissappears to not cover screen
        HideTip();
    }

    private void ShowTip(string tip, Vector2 MousePos)
    {
        // sets tip size and text
        tipText.text = tip;
        tipWindow.sizeDelta = new Vector2(tipText.preferredWidth > 150 ? 150 : tipText.preferredWidth, tipText.preferredHeight+35);

        tipWindow.gameObject.SetActive(true);
        tipWindow.transform.position = new Vector2(MousePos.x-tipWindow.sizeDelta.x-70, MousePos.y);
    }

    private void HideTip()
    {
        // disappears tip and resets text
        tipText.text = default;
        tipWindow.gameObject.SetActive(false);
    }
    
}
