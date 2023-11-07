using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Validation : MonoBehaviour
{
    public Material[] mats;
    OutlineBuild outlineBuild;
    Renderer rend;
    private void Start()
    {
        outlineBuild = GetComponent<OutlineBuild>();
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = mats[0];
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Buildings")
        {
            rend.sharedMaterial = mats[1];
        }
        
    }
}
