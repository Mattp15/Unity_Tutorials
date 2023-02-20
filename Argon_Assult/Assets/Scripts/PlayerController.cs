using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [Header("General Setup Settings")]
    [Tooltip("Player input getter")] [SerializeField] InputAction movement;
    [Header("Screen Position Tuning")]
    [Tooltip("Movement Speed")] [SerializeField] float controlSpeed = 30f;
    [Tooltip("Left and right screen limit")] [SerializeField] float xRange = 9f;
    [Tooltip("Up and down screen limit")] [SerializeField] float yRange = 7.5f;
    
    [Header("Player movement control")]
    [Tooltip("How much the object tilts up and down - not using")] [SerializeField] float positionPitchFactor = -2f;
    [Tooltip("The speed of the tilt up and down - not using")] [SerializeField] float controlPitchFactor = -15f;
    [Tooltip("")] [SerializeField] float positionYawFactor = 2f;    
    [Tooltip("")] [SerializeField] float controlRollFactor = -20f; 
    [SerializeField] InputAction fire;   
    [SerializeField] GameObject[] lasers;

    float xThrow, yThrow;

    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnEnable() { //unity order of execution docs.unity3d.com/Manual/ExecutionOrder.html
        movement.Enable();
        fire.Enable();
    }
    private void OnDisable() {
        movement.Disable();
        fire.Disable();
    }
    void Update()
    {
        processTranslation();
        processRotation();
        processFiring();

    }


    private void processTranslation()
    {
        //BELOW IS OLD SYSTEM
        // xThrow = Input.GetAxis("Horizontal");
        // yThrow = Input.GetAxis("Vertical");

        //Below is the new system
        xThrow = movement.ReadValue<Vector2>().x;//.x impliments horizontal axis (x-axis)
        yThrow = movement.ReadValue<Vector2>().y;//.y impliments vertical axis (y-axis)
        //Get X movement
        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        //Get Y movement
        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);
        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }  
    private void processRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        // float pitchDueToControllThrow = yThrow * controlPitchFactor;// This makes the ship focus on the center of the screen up and down lock at -35 at max throw
        float pitchDueToControllThrow = 0;//doesn't pitch but looks better than ^
        
        float pitch = pitchDueToPosition * pitchDueToControllThrow;         
        float yaw = transform.localPosition.x * positionYawFactor; //yaw control's turning left and right, i don't want
        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
    void processFiring()
    {
        //if pushing fire button
        // then do the shooting else don't do the shooting
        if (fire.ReadValue<float>() > 0.5f)
        {
            SetLasersActive(true);
        }
        else
        {
            SetLasersActive(false);;
        }
    }

    private void SetLasersActive(bool isActive)
    {
        //Activate both lasers

        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
        

    }

}
