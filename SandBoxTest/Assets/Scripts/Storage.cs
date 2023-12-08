using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    private bool start = false;

    private void Update()
    {
        Debug.Log(WoodStorage);
        Debug.Log(IronStorage);
        Debug.Log(CoalStorage);
        Debug.Log(PopCapStorage);
        Debug.Log(researchStorage);
        UpdateStorageDisplay();
        cap();
        if(SceneManager.GetActiveScene().name== "Tutorial" && start == false)
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
        WoodStorage = 70;
        IronStorage = 50;
        CoalStorage = 150;
        PopCapStorage = 5;
        researchStorage = 0;
        Population = 0;
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
