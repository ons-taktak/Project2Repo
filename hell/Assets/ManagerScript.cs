using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScript : MonoBehaviour
{
    public GameObject prompt;
    public GameObject lose;
    public GameObject win;
    public GameObject blank;

    public Animator wheel1;
    public Animator wheel2;

    public Animator wheel3;
    public Animator wheel4;

    public Animator wheel5;

    public Animator wheel6;

    public Animator wheel7;


    public Animator wheel8;
    public Animator wheel9;

    public Animator wheel10;
    public Animator wheel11;

    public Animator wheel12;

    public Animator wheel13;

    public Animator wheel14;

    public  int n = 0;

    public GameObject _randomWheel;

    public GameObject winnerwheel;



    // variables to move camera down
    public GameObject XRRig;
    public GameObject RigDestination;
    public float timeBeforeCameraMoves = 2.0f;


    // Start is called before the first frame update
    void Start()
    {
        prompt.SetActive(true);
        lose.SetActive(false);
        win.SetActive(false);
        blank.SetActive(false);

        n = 0; 

        

        
    }

   

    private void OnTriggerEnter(Collider other)
    {
        //wrap in if statement, if the tag is the coin tag then carry statement
        //other.gameobject , .comparetag
        //put the string in the tab name to compare the function. 
        if (other.gameObject.CompareTag("coin"))
        {
            n++;



            //coin tag , check if the other collider has the tag coin. 
            if (n == 1)
            {
                wheel1.GetComponent<Animator>().enabled = true;
                wheel2.GetComponent<Animator>().enabled = true;
                wheel3.GetComponent<Animator>().enabled = true;
                wheel4.GetComponent<Animator>().enabled = true;
                wheel5.GetComponent<Animator>().enabled = true;
                wheel6.GetComponent<Animator>().enabled = true;
                wheel7.GetComponent<Animator>().enabled = true;

                blank.SetActive(true);
                winnerwheel.SetActive(false);

                Invoke("turnoff", 3.0f);

            }

            if (n == 2)
            {
                wheel1.GetComponent<Animator>().enabled = true;
                wheel2.GetComponent<Animator>().enabled = true;
                wheel3.GetComponent<Animator>().enabled = true;
                wheel4.GetComponent<Animator>().enabled = true;
                wheel5.GetComponent<Animator>().enabled = true;
                wheel6.GetComponent<Animator>().enabled = true;
                wheel7.GetComponent<Animator>().enabled = true;

                blank.SetActive(true);
                winnerwheel.SetActive(false);

                Invoke("turnoff", 3.0f);

            }

            if (n == 3)
            {
                wheel8.GetComponent<Animator>().enabled = true;
                wheel9.GetComponent<Animator>().enabled = true;
                wheel10.GetComponent<Animator>().enabled = true;
                wheel11.GetComponent<Animator>().enabled = true;
                wheel12.GetComponent<Animator>().enabled = true;
                wheel13.GetComponent<Animator>().enabled = true;
                wheel14.GetComponent<Animator>().enabled = true;

                winnerwheel.SetActive(true);

                lose.SetActive(false);
                blank.SetActive(true);

                _randomWheel.SetActive(false);

                Invoke("won", 3.0f);

            }
        }
    }

    public void turnoff()
    {
        wheel1.GetComponent<Animator>().enabled = false;
        wheel2.GetComponent<Animator>().enabled = false;
        wheel3.GetComponent<Animator>().enabled = false;
        wheel4.GetComponent<Animator>().enabled = false;
        wheel5.GetComponent<Animator>().enabled = false;
        wheel6.GetComponent<Animator>().enabled = false;
        wheel7.GetComponent<Animator>().enabled = false;

        blank.SetActive (false);

        lose.SetActive(true);

    }


    public void won()
    {
        wheel8.GetComponent<Animator>().enabled = false;
        wheel9.GetComponent<Animator>().enabled = false;
        wheel10.GetComponent<Animator>().enabled = false;
        wheel11.GetComponent<Animator>().enabled = false;
        wheel12.GetComponent<Animator>().enabled = false;
        wheel13.GetComponent<Animator>().enabled = false;
        wheel14.GetComponent<Animator>().enabled = false;

        blank.SetActive(false);
        win.SetActive(true);

        _randomWheel.SetActive(false);

        //start the coroutine for moving the camera here
        StartCoroutine(MoveCamera());

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
