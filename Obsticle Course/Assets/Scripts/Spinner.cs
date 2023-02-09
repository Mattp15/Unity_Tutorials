using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] float xAngle;
    [SerializeField] float yAngle;
    [SerializeField] float zAngle;

    

    // Update is called once per frame
    void Update()
    {
        xAngle = 0f;
        yAngle = 0.5f;
        zAngle = 0f;
        transform.Rotate(xAngle, yAngle, zAngle);
    }
}
