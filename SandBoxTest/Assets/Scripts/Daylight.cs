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
        if(Time.timeScale <= 0)
        {
            return;
        }
        rot.x = degpersec * Time.deltaTime;
        transform.Rotate(rot, Space.World);
        if (rot.x >= 190 || rot.x <= 0)
        {
            if(gameObject.GetComponent<Light>().intensity ==  0)
            {
                gameObject.GetComponent<Light>().intensity = 0f;
            }
            else
            {
                gameObject.GetComponent<Light>().intensity -= 0.1f;
            }
        }
        else
        {
            if(gameObject.GetComponent <Light>().intensity == 1) 
            {
                gameObject.GetComponent<Light>().intensity = 1f;
            }
            else
            {

                gameObject.GetComponent<Light>().intensity += 0.1f;
            }
        }
    }
}
