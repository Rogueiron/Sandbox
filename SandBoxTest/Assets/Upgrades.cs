using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Storage;

public class Upgrades : MonoBehaviour
{
    [SerializeField] private int ResearchNeeded;
    public static bool Speed;
    public static bool Amount;

    private void Start()
    {
        Speed = false;
        Amount = false;
    }
    private void Update()
    {

    }
    public void SpeedBought()
    {
        if(researchStorage >= ResearchNeeded)
        {
            Speed = true;
        }

    }
    public void AmountBought()
    {
        if (researchStorage >= ResearchNeeded)
        {
            Amount = true;
        }

    }
}
