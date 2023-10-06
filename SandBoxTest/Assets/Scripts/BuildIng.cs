using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildIng : MonoBehaviour
{
    public GameObject building;
    public void build()
    {
        Instantiate(building);
    }
}
