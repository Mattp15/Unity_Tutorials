using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApplication : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("quitting");
            Application.Quit(); //This won't show anything while compiling in unity - this fully closes the application
        }
    }
}
