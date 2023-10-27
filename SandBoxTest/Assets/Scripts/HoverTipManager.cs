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
        OnMouseHover += ShowTip;
        OnMouseMiss += HideTip;
    }

    private void OnDisable()
    {
        OnMouseHover -= ShowTip;
        OnMouseMiss -= HideTip;
    }

    void Start()
    {
        HideTip();
    }

    private void ShowTip(string tip, Vector2 MousePos)
    {
        tipText.text = tip;
        tipWindow.sizeDelta = new Vector2(tipText.preferredWidth > 400 ? 400 : tipText.preferredWidth, tipText.preferredHeight);

        tipWindow.gameObject.SetActive(true);
        tipWindow.transform.position = new Vector2(MousePos.x-tipWindow.sizeDelta.x, MousePos.y);
    }

    private void HideTip()
    {
        tipText.text = default;
        tipWindow.gameObject.SetActive(false);
    }
    
}
