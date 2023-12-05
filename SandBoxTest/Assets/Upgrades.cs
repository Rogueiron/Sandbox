using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Storage;

public class Upgrades : MonoBehaviour
{
    [SerializeField] private int ResearchNeeded;
    public static bool Speed;

    private void Start()
    {
        Speed = false;
    }
    private void Update()
    {
        Debug.Log(Speed);
    }
    public void SpeedBought()
    {
        if(researchStorage >= ResearchNeeded)
        {
            Speed = true;
        }

    }
}
