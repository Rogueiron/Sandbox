using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Storage;
using static tutorial;

public class Upgrades : MonoBehaviour
{
    [SerializeField] private int SResearchNeeded;
    [SerializeField] private int AResearchNeeded;
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
        if(researchStorage >= SResearchNeeded)
        {
            researchStorage -= SResearchNeeded;
            Speed = true;
        }
        if(SceneManager.GetActiveScene().name == "Tutorial")
        {
            tutorial.Once = false;
            step++;
        }

    }
    public void AmountBought()
    {
        if (researchStorage >= AResearchNeeded)
        {
            Amount = true;
        }

    }
}
