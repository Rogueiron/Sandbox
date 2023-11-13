using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Storage : MonoBehaviour
{
    public static int WoodStorage = 30;
    public static int IronStorage = 20;
    public static int PopCapStorage = 0;
    public static int researchStorage = 0;

    [SerializeField] TextMeshProUGUI storageText;

    private void Update()
    {
        UpdateStorageDisplay();
    }
    private void UpdateStorageDisplay()
    {
        storageText.text = "Wood: " + WoodStorage + "\nIron:" + IronStorage;
    }
}
