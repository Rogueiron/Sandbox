using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CostShower : MonoBehaviour
{
    [SerializeField] bool isWood;
    [SerializeField] Button ValueGrabber;

    void Start()
    {
           // Grabs the needed value to display to the player the cost of something
        if(isWood)
        {
            GetComponent<TextMeshProUGUI>().SetText(ValueGrabber.GetComponent<UnitToMake>().getWoodCost().ToString());
        }
        else
        {
            GetComponent<TextMeshProUGUI>().SetText(ValueGrabber.GetComponent<UnitToMake>().getIronCost().ToString());
        }
    }
}
