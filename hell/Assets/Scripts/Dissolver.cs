using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Dissolver : MonoBehaviour
{
    //variables for appearing effect
    [SerializeField] private Renderer dissolveRenderer;
    private float targetValue = 0f;
    private float currentValue = 1f;
    public float waitingTime = 9.0f;

    //variables for fingerprint 
    public GameObject fingerprint;
    public float speed = 4.0f;
    XRRayInteractor rayInteractor;
    bool allowFingerprint = false; //boolean to check if the documetn has fully appeared

    private void Start()
    {
        fingerprint.SetActive(false);
        StartCoroutine(Appear());
    }

    //coroutine for making the document appear
    IEnumerator Appear()
    {
        yield return new WaitForSeconds(waitingTime);

        while (currentValue > 0.2f)
        {
            currentValue = Mathf.Lerp(currentValue, targetValue, Time.deltaTime);
            dissolveRenderer.material.SetFloat("_DissolveAmount", currentValue);
            yield return null;
        }
        allowFingerprint = true;



    }

    //follow controllers for the fingerprint
    public void FollowStart(HoverEnterEventArgs args)
    {
        if (rayInteractor == null)
        {
            rayInteractor = args.interactor as XRRayInteractor;
            if (rayInteractor != null)
            {
                //start following
                StartCoroutine(Follow());
            }
        }
    }

    public void FollowStop()
    {
        //stop following
        StopCoroutine(Follow());
        rayInteractor = null;
        fingerprint.SetActive(false);
    }

    IEnumerator Follow()
    {
        while (true)
        {
            if (rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit) && allowFingerprint == true)
            {
                fingerprint.transform.position = Vector3.MoveTowards(fingerprint.transform.position, hit.point, speed * Time.deltaTime);
                fingerprint.SetActive(true);
            }
            yield return null;
        }
       
    }

}
