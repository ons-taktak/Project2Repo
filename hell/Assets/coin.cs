using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Rigidbody>().useGravity = true;
    }
//enable gravity function
//comment out the onMouse donw, use the line
//add a grab interactable
    
       
       // ManagerScript.n = +1;
    

    // Update is called once per frame
    void Update()
    {
      
    }
}
