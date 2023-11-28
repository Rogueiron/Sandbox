using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regrow : MonoBehaviour
{
    RegrowTimer regrowTimer;
    private void Start()
    {
        regrowTimer = GetComponentInParent<RegrowTimer>();
    }
    private void OnDestroy()
    {
        regrowTimer.time();
    }
}
