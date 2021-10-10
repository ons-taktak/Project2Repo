using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAppear : MonoBehaviour
{
    public float waitingTime = 3.0f;
    public float activeTime = 10.0f;
    public ParticleSystem fire;
    

    private void Start()
    {
        fire.Stop();
        StartCoroutine(Appear());
    }

    IEnumerator Appear()
    {
        yield return new WaitForSeconds(waitingTime);
        fire.Play();

        yield return new WaitForSeconds(activeTime);
        fire.Stop(); 
    }
}
