using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [SerializeField] InputAction movement;
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
        //BELOW IS OLD SYSTEM
        // float horizontalThrow = Input.GetAxis("Horizontal");
        // float verticalThrow = Input.GetAxis("Vertical");

        //Below is the new system
        float xThrow = movement.ReadValue<Vector2>().x;//.x impliments horizontal axis (x-axis)
        float yThrow = movement.ReadValue<Vector2>().y;//.y impliments vertical axis (y-axis)
        //Get X movement
        float xOffset = xThrow * Time.deltaTime;
        float newXPos = transform.localPosition.x + xOffset;
        //Get Y movement
        float yOffset = yThrow * Time.deltaTime;
        float newYPos = transform.localPosition.y + yOffset;

        transform.localPosition = new Vector3(newXPos, newYPos, transform.localPosition.z);
        
       


    }
}
