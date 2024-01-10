using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static Storage;
using static WaterStorage;

public class tutorial : MonoBehaviour
{
    public static int step = 0;
    public static bool Once = false;
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
                WaterPump.SetActive(true);
                if(Once == false)
                {
                    IronStorage = 20;
                    Tutorialtext.text = "We have given you some starting iron to use to make a water pump. Water pumps collect water from he clouds so place it on the edge. The waterpump will show up blue when it is able to be placed try placing it.";
                    Once = true;
                }
                if(IronStorage <= 0)
                {
                    Tutorialtext.text = "Waterpumps help get water which you need to get power to make bots. All bots take 5 water look in the bottom left conner to see the resources. The onw on top is wood to the left in the middle is water and finally the last one is iron.";
                }
                if(Waterstorage >= 10)
                {
                    Once = false;
                    step++; ;
                }
                break;
            case 2:
                if (IronStorage <= 0 && Once == false)
                {
                    IronStorage = 10;
                    Woodgetter.SetActive(true);
                    Tutorialtext.text = "Use Iron to make new Tree bot. Please try making a new bot.";
                    Once = true;
                }

                if (IronStorage <= 0)
                {
                    Once = false;
                    step++; ;
                }
                break;
            case 3:
                if (WoodStorage <= 0 && Once == false)
                {
                    Tutorialtext.text = "Now use Wood to make new Iron bot. Please try making a new bot.";
                    WoodStorage = 10;
                    Irongetter.SetActive(true);
                    Once = true;
                }
                if (WoodStorage <= 0)
                {
                    Once = false;
                    step++;
                }
                break;
            case 4:
                if(WoodStorage <= 0 && Once == false)
                {
                    Tutorialtext.text = "Building also take wood and iron to make. Wait for the bots to get new materials.";
                    manor.SetActive(true);
                    Once = true;
                }
                if (WoodStorage >= 10)
                {
                    Tutorialtext.text = "Manors take 10 wood to build and incease the max amount of bots you can have. Please make a manor";
                    Timer -= Time.deltaTime;
                }
                else if(WoodStorage <= 0 && Timer <= 0 ) 
                {
                    Once = false;
                    step++;
                }
                else
                {
                    Timer -= Time.deltaTime;
                }
                break;
            case 5:
                if(researchStorage <= 0 && Once == false)
                {
                    research.SetActive(true);
                    researchStorage = 10;
                    Tutorialtext.text = "You can use Research to upgrade the bots. Look back to the bottom left conner that little circle is research. Click the research button.";
                    Once = true;
                }
                if(ResearchCanvas.enabled == true)
                {
                    RTutorialtext.color = Color.white;
                    RTutorialtext.text = "Get the harvest speed upgrade to decrease the time it takes to destory tree and iron.";
                }
                break;
            case 6:
                if (ResearchCanvas.enabled == true)
                {
                    RTutorialtext.color = Color.white;
                    RTutorialtext.text = "Hit escape to go back to the game view.";
                }
                if(ResearchCanvas.enabled == false && Once == false)
                {
                    Tutorialtext.text = "Now Watches those bots work.";
                    Once = true;
                }
                if(WoodStorage >= 10)
                {
                    Once = false;
                    step++;
                }
                break;
            case 7:
                Tutorialtext.text = "Thats the end of the tutorial you may mess around for a bit. Once finished Hold down Escape and go back to the main menu.";
                break;

        }
    }
}
