using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBob : MonoBehaviour
{
    public Transform target;
    private float turnspeed = .1f;

    private Coroutine LookCoroutine;
    // Start is called before the first frame update
    void Update()
    {
        if(LookCoroutine != null)
        {
            StopCoroutine(LookCoroutine);
        }
        LookCoroutine = StartCoroutine(LookAt());
    }
    private IEnumerator LookAt()
    {
        Quaternion lookRotation = Quaternion.LookRotation(target.position - transform.position);
        float time = 0;
        while (time < 1)
        {
            transform.rotation= Quaternion.Slerp(transform.rotation, lookRotation, time);
            time += Time.deltaTime * turnspeed;
        }
        yield return null;
    }
}
