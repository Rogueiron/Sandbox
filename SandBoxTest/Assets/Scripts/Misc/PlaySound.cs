using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    private AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        try
        {
            sound = GetComponent<AudioSource>();
        }
        catch
        {
            Debug.Log("Component not found");
        }

    }
    void Awake()
    {
        sound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
