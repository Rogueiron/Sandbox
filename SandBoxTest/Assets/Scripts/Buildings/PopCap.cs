using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Storage;

public class PopCap : MonoBehaviour
{
    public void Start()
    {
        //when manor is placed increase make population
        PopCapStorage += 5;
    }
}
