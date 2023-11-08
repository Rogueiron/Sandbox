using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    public static int WoodStorage = 30;
    public static int IronStorage = 10;
    public static int PopCapStorage = 0;
    public static int researchStorage = 0;

    private void Update()
    {
        Debug.Log(WoodStorage);
        Debug.Log(IronStorage);
        Debug.Log(PopCapStorage);
        Debug.Log(researchStorage);
    }
}
