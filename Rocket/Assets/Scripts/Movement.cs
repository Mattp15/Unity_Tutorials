using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb; 
    [SerializeField]float mainThrust = 1000f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
         ProcessThrust();
         ProcessRotation();        
    }


    void ProcessThrust() 
    {
    if (Input.GetKey(KeyCode.Space))
        {
            //Check out vector shortcuts up = 0, 1, 0
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        }
    }


    void ProcessRotation()
    {
    if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward);
        } 
        else if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward);
        }
    }
}