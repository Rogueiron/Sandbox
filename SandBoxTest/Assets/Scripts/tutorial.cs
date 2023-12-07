using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static Storage;

public class tutorial : MonoBehaviour
{
    public static int step = 0;
    private bool Bool = false;
    private float Timer = 20;

    [SerializeField] private GameObject manor;
    [SerializeField] private GameObject WaterPump;
    [SerializeField] private GameObject research;
    [SerializeField] private GameObject Woodgetter;
    [SerializeField] private GameObject Irongetter;
    [SerializeField] private Canvas ResearchCanvas;
    [SerializeField] TextMeshProUGUI Tutorialtext;
    [SerializeField] TextMeshProUGUI RTutorialtext;
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
                    Tutorialtext.text = "Use Iron to make new Tree bot. Please try making a new bot.";
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
                    Tutorialtext.text = "Now use Wood to make new Iron bot. Please try making a new bot.";
                    WoodStorage = 10;
                    Irongetter.SetActive(true);
                    Bool = true;
                }
                if (WoodStorage <= 0)
                {
                    Bool = false;
                    step++;
                }
                break;
            case 3:
                if(WoodStorage <= 0 && Bool == false)
                {
                    Tutorialtext.text = "Building also take wood and iron to make. Wait for the bots to get new materials.";
                    manor.SetActive(true);
                    Bool = true;
                }
                if (WoodStorage >= 10)
                {
                    Tutorialtext.text = "Manors take 10 wood to build and incease the max amount of bots you can have. Please make a manor";
                    Timer -= Time.deltaTime;
                }
                else if(WoodStorage <= 0 && Timer <= 0 ) 
                {
                    Bool = false;
                    step = 4;
                }
                else
                {
                    Timer -= Time.deltaTime;
                }
                break;
            case 4:
                if(researchStorage <= 0 && Bool == false)
                {
                    research.SetActive(true);
                    researchStorage = 10;
                    Tutorialtext.text = "You can use Research to upgrade the bots. Click the research button.";
                    Bool = true;
                }
                if(ResearchCanvas.enabled == true)
                {
                    RTutorialtext.color = Color.white;
                    RTutorialtext.text = "Get the harvest speed upgrade to decrease the time it takes to destory tree and iron.";
                }
                break;
        
        }
    }
}
