using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    private float speed = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Vector3.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Core").transform.position, speed);
    }
}
