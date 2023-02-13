using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(0,1)] float movementFactor;
    [SerializeField] float period = 10f;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        const float tau = Mathf.PI * 2;
        float cycles = Time.time / period;
        float rawSinWage = Mathf.Sin(cycles * tau);

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
