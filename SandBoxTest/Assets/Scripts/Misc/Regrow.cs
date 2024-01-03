using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regrow : MonoBehaviour
{
    RegrowTimer regrowTimer;
    private void Start()
    {
        //gets regrowtimer component in parent
        regrowTimer = GetComponentInParent<RegrowTimer>();
    }
    private void OnDestroy()
    {
        //when tree is destroyed start regrow timer
        regrowTimer.time();
    }
}
