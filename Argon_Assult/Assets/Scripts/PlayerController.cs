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
        float horizontalThrow = movement.ReadValue<Vector2>().x;//.x impliments horizontal axis (x-axis)
        float verticalThrow = movement.ReadValue<Vector2>().y;//.y impliments vertical axis (y-axis)
        //BELOW IS OLD SYSTEM
        // float horizontalThrow = Input.GetAxis("Horizontal");
        Debug.Log(horizontalThrow);
        // float verticalThrow = Input.GetAxis("Vertical");
        Debug.Log(verticalThrow);


    }
}
