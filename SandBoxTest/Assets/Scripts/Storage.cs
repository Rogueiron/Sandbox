using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Storage : MonoBehaviour
{
    public static int WoodStorage = 30;
    public static int IronStorage = 20;
    public static int WaterStorage = 50;
    public static int CoalStorage = 100;
    public static int PopCapStorage = 0;
    public static int researchStorage = 0;

    [SerializeField] TextMeshProUGUI storageTextWo;
    [SerializeField] TextMeshProUGUI storageTextI;
    [SerializeField] TextMeshProUGUI storageTextWa;
    [SerializeField] TextMeshProUGUI storageTextC;

    private void Update()
    {
        UpdateStorageDisplay();
        cap();
    }
    private void UpdateStorageDisplay()
    {
        storageTextWo.text = WoodStorage.ToString();
        storageTextI.text = IronStorage.ToString();
        storageTextWa.text = WaterStorage.ToString();
        storageTextC.text = CoalStorage.ToString();
    }
    private void cap()
    {
        if(WoodStorage < 0)
        {
            WoodStorage = 0;
        }
        if (IronStorage < 0)
        {
            IronStorage = 0;
        }
        if (WaterStorage < 0)
        {
            WaterStorage = 0;
        }
        if (CoalStorage < 0)
        {
            CoalStorage = 0;
        }
    }
}
