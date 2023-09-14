using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FpsCap : MonoBehaviour
{
    public TMPro.TMP_Dropdown dropdown;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    public void fpsChange()
    {
        if (dropdown.value == 0)
        {
            Application.targetFrameRate = 120;
        }
        else if (dropdown.value == 1)
        {
            Application.targetFrameRate = 60;
        }
        else if (dropdown.value == 2)
        {
            Application.targetFrameRate = 30;
        }
    }
}
