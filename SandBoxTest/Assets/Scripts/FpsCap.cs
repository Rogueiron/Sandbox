using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FpsCap : MonoBehaviour
{
    private Dropdown dropdown;
    // Start is called before the first frame update
    void Start()
    {
        dropdown = GameObject.FindGameObjectWithTag("Dropdown").GetComponent<Dropdown>();
    }

    // Update is called once per frame
    void Update()
    {
        if(dropdown.value == 1)
        {
            Application.targetFrameRate = 30;
        }
        if (dropdown.value == 2)
        {
            Application.targetFrameRate = 60;
        }
        if (dropdown.value == 3)
        {
            Application.targetFrameRate = 120;
        }
    }
}
