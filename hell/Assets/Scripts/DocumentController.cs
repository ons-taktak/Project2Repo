using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DocumentController : MonoBehaviour
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
    bool stamped = false;

    // variables to move camera down
    public GameObject XRRig;
    public GameObject RigDestination;
    public float timeBeforeCameraMoves = 3.0f;


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
        if (stamped == false)
        {
            fingerprint.SetActive(false);
        }
    }

    IEnumerator Follow()
    {
        while (true)
        {
            if (rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit) && allowFingerprint == true && stamped == false )
            {
                fingerprint.transform.position = Vector3.MoveTowards(fingerprint.transform.position, hit.point, speed * Time.deltaTime);
                fingerprint.SetActive(true);
            }
            yield return null;
        }
       
    }

    public void StampFingerprint()
    {
        //stamp and stop following
        if (allowFingerprint == true)
        {
            StopCoroutine(Follow());
            rayInteractor = null;
            Renderer r = fingerprint.GetComponent<Renderer>();
            Color opaque = r.material.color;
            opaque.a = 195.0f / 255.0f;

            r.material.color = opaque;

            stamped = true;
            //start the coroutine for moving the camera here
            StartCoroutine(MoveCamera());
        }

    }

    IEnumerator MoveCamera()
    {
        yield return new WaitForSeconds(timeBeforeCameraMoves);
        while (XRRig.transform.position != RigDestination.transform.position)
        {
            XRRig.transform.position = Vector3.MoveTowards(XRRig.transform.position, RigDestination.transform.position, 2 * Time.deltaTime);
            yield return null;
        }
    }


}
