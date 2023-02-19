using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [SerializeField] InputAction movement;
    float xRange = 10f;
    float yRange = 7f;
    float controlSpeed = 30f;
    float xThrow, yThrow;
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -15f;
    [SerializeField] float positionYawFactor = 2f;    
    [SerializeField] float controlRollFactor = -20f;    



    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnEnable() { //unity order of execution docs.unity3d.com/Manual/ExecutionOrder.html
        movement.Enable();
    }
    private void OnDisable() {
        movement.Disable();
    }
    void Update()
    {
        processTranslation();
        processRotation();

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

    private void processTranslation()
    {
        //BELOW IS OLD SYSTEM
        // float horizontalThrow = Input.GetAxis("Horizontal");
        // float verticalThrow = Input.GetAxis("Vertical");

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
        Debug.Log(transform.localPosition.z + yOffset);
    }
}
