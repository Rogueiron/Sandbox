using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static WaterStorage;

public class Storage : MonoBehaviour
{
    public static int WoodStorage = 100;
    public static int IronStorage = 100;
    public static int CoalStorage = 150;
    public static int PopCapStorage = 5;
    public static int researchStorage = 0;
    public static int Population = 0;

    [SerializeField] TextMeshProUGUI storageTextWo;
    [SerializeField] TextMeshProUGUI storageTextI;
    [SerializeField] TextMeshProUGUI storageTextWa;
    [SerializeField] TextMeshProUGUI storageTextC;
    [SerializeField] TextMeshProUGUI storageTextR;

    private bool start = false;

    private void Update()
    {
        UpdateStorageDisplay();
        cap();
        //checks to see if is the tutorial if so set resources to zero
        if (SceneManager.GetActiveScene().name== "Tutorial" && start == false)
        {
            WoodStorage = 0;
            IronStorage = 0;
            CoalStorage = 0;
            Waterstorage = 0;
            start = true;
        }
    }
    private void OnDestroy()
    {
        //when ganeobject with script is destory reset resources
        WoodStorage = 70;
        IronStorage = 50;
        CoalStorage = 150;
        PopCapStorage = 5;
        researchStorage = 0;
        Population = 0;
    }

    private void UpdateStorageDisplay()
    {
        //shows the resources to the screen
        storageTextWo.text = WoodStorage.ToString();
        storageTextI.text = IronStorage.ToString();
        storageTextWa.text = Waterstorage.ToString();
        storageTextC.text = CoalStorage.ToString();
        storageTextR.text = researchStorage.ToString();
    }
    private void cap()
    {
        //resources can't go passed zero or 999
        if(WoodStorage < 0)
        {
            WoodStorage = 0;
        }
        else if(WoodStorage >999)
        {
            WoodStorage = 999;
        }
        if (IronStorage < 0)
        {
            IronStorage = 0;
        }
        else if (IronStorage > 999)
        {
            IronStorage = 999;
        }
        if (Waterstorage < 0)
        {
            Waterstorage = 0;
        }
        else if(Waterstorage > 999)
        {
            Waterstorage = 999;
        }
        if (CoalStorage < 0)
        {
            CoalStorage = 0;
        }
    }
}
