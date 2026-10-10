using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestroy : MonoBehaviour
{
    public GameObject light;
    public float secondsToWait = 2f;
    public float secondsToWaitLight = 0.1f;
    
    void Start()
    {
        StartCoroutine(dead());
        StartCoroutine(lightDead());
    }

    IEnumerator dead()
    {
        yield return new WaitForSeconds(secondsToWait);

        Destroy(gameObject);
    }

    IEnumerator lightDead()
    {
        yield return new WaitForSeconds(secondsToWaitLight);

        Destroy(light);
    }
}
