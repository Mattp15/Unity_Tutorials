using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    //SeralizeField gives Unity the access to the variables to change in app, however chaning them in unity interface will not change them in the script
    [SerializeField] float xValue = 0.01f;
    [SerializeField] float yValue = 0.0f;
    [SerializeField] float zValue = 0.0f;
    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        count++;
        if(count >= 1000)
        {
            xValue = -xValue;
            count = 0;
        } 
        transform.Translate(xValue, yValue, zValue);

    }
}
