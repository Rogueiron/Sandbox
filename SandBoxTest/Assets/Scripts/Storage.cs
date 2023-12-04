using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static WaterStorage;

public class Storage : MonoBehaviour
{
    public static int WoodStorage = 70;
    public static int IronStorage = 50;
    public static int CoalStorage = 150;
    public static int PopCapStorage = 5;
    public static int researchStorage = 0;
    public static int Population = 0;

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
        storageTextWa.text = Waterstorage.ToString();
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
        if (Waterstorage < 0)
        {
            Waterstorage = 0;
        }
        if (CoalStorage < 0)
        {
            CoalStorage = 0;
        }
    }
}
