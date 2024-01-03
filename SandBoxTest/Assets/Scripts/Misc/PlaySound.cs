using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    private AudioSource sound;
    void Start()
    {
        //try to get the sound componet
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
        //when building placed play sound
        sound.Play();
    }
}
