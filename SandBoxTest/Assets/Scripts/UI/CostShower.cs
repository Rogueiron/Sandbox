using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CostShower : MonoBehaviour
{
    [SerializeField] bool isWood;
    [SerializeField] Button ValueGrabber;
    private TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();

        if(ValueGrabber.GetComponent<BuildIng>())
        {
            if (isWood)
            {
                text.SetText(ValueGrabber.GetComponent<BuildIng>().woodsNeeded.ToString());
            }
            else
            {
                text.SetText(ValueGrabber.GetComponent<BuildIng>().ironNeeded.ToString());
            }
                
        }
        else if(ValueGrabber.GetComponent<CompleteLevel>())
        {
            if(isWood)
            {
                text.SetText(ValueGrabber.GetComponent<CompleteLevel>().wood.ToString());
            }
            else
            {
                text.SetText(ValueGrabber.GetComponent<CompleteLevel>().iron.ToString());
            }
        }
        else
        {
            if (isWood)
            {
                text.SetText(ValueGrabber.GetComponent<UnitToMake>().getWoodCost().ToString());
            }
            else
            {
                text.SetText(ValueGrabber.GetComponent<UnitToMake>().getIronCost().ToString());
            }
        }

    }
}
