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
    }
    private void UpdateStorageDisplay()
    {
        storageTextWo.text = WoodStorage.ToString();
        storageTextI.text = IronStorage.ToString();
        storageTextWa.text = WaterStorage.ToString();
        storageTextC.text = CoalStorage.ToString();
    }
}
