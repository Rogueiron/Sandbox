using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public Canvas buildmode;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.B))
        {
            buildmode.enabled = true;
        }
        else
        {
            buildmode.enabled = false;
        }
    }
}
