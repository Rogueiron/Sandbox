using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static Storage;

public class tutorial : MonoBehaviour
{
    public static int step = 0;
    private bool Bool = false;

    [SerializeField] private GameObject manor;
    [SerializeField] private GameObject WaterPump;
    [SerializeField] private GameObject research;
    [SerializeField] private GameObject Woodgetter;
    [SerializeField] private GameObject Irongetter;
    void Update()
    {
        switch(step) 
        {
            case 0:
                manor.SetActive(false);
                WaterPump.SetActive(false);
                research.SetActive(false);
                Woodgetter.SetActive(false);
                Irongetter.SetActive(false);
                step = 1;
                break;
            case 1:
                if (IronStorage <= 0 && Bool == false)
                {
                    IronStorage = 10;
                    Woodgetter.SetActive(true);
                    Bool = true;
                }

                if (IronStorage <= 0)
                {
                    Bool = false;
                    step = 2;
                }
                break;
            case 2:
                if (WoodStorage <= 0 && Bool == false)
                {
                    WoodStorage = 10;
                    Irongetter.SetActive(true);
                    Bool = true;
                }
                if (WoodStorage <= 0 && Input.GetMouseButtonDown(0))
                {
                    Bool = false;
                    step++;
                }
                break;
            case 3:
                manor.SetActive(true);
                break;
        
        }
    }
}
