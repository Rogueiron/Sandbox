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
    public static bool Bool = false;
    private float Timer = 20;
    private int invisable = 1;

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
        //uses a switch to keep track of all the steps int the tutorial
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
            case 5:
                if (ResearchCanvas.enabled == true)
                {
                    RTutorialtext.color = Color.white;
                    RTutorialtext.text = "Hit escape to go back to the game view.";
                }
                if(ResearchCanvas.enabled == false && Bool == false)
                {
                    Tutorialtext.text = "Now Watches those bots work.";
                    Bool = true;
                }
                if(IronStorage >= 10 && WoodStorage >= 20)
                {
                    WaterPump.SetActive(true);
                    Tutorialtext.text = "Now you can make a water pump.";
                }
                else if(invisable != 1)
                {
                    if(Input.GetMouseButtonDown(0)) 
                    {
                        step = 6;
                    }
                    Tutorialtext.text = "Water pumps collect water from he clouds so place it on the edge. The waterpump will show up blue when it is able to be placed try placing it.";
                }
                if(WoodStorage >= 20 && IronStorage >= 10)
                {
                    invisable = 0;
                }
                break;
            case 6:
                Tutorialtext.text = "Thats the end of the tutorial you may mess around for a bit. Once finished Hold down Escape and go back to the main menu.";
                break;

        }
    }
}
