using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Pressed SPACE - THRUSTING");
        }
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Rotating Left");
        }
        if(Input.GetKey(KeyCode.D))
        {
            Debug.Log("Rotating Right");
        }
    }
}
