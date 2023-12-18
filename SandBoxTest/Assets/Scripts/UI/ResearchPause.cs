using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchPause : MonoBehaviour
{
    public Canvas main;
    public Canvas pause;
    public Canvas research;
    public void Researchclick()
    {
        main.enabled = false;
        pause.enabled = false;
        research.enabled = true;
    }
}
