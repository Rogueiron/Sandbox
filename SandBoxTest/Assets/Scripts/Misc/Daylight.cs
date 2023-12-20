using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daylight : MonoBehaviour
{
    Vector3 rot = Vector3.zero;
    float degpersec = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //rotate the directional light aka the sun to make a day night cycle
        if(Time.timeScale <= 0)
        {
            return;
        }
        rot.x = degpersec * Time.deltaTime;
        transform.Rotate(rot, Space.World);
    }
}
