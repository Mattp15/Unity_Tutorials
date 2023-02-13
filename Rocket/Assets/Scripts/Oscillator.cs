using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [SerializeField] Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    float movementFactor; //determins the movement distance
    [SerializeField] float period = 20f;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        movementFactor = 0;
    }

    // Update is called once per frame
    void Update()
    {
        const float tau = Mathf.PI * 2;//const value of double pie 6.283 apparently better for circles
        float cycles = Time.time / period;
        float rawSinWave = Mathf.Sin(cycles * tau); //TextGenerationSettings from -1 to 1

        movementFactor = (rawSinWave + 1) /2f; //recalculated to go from 0 to 1 so its "cleaner"

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
