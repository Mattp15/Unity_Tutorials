using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2f;
    
     void OnCollisionEnter(Collision other) 
    {
        switch(other.gameObject.tag)
        {
            case "Finish":
                StartSuccessSequence();
                break;
            case "Friendly":
                break;
            default:
                CrashSequence();
                break;
        }    
    }

    private void StartSuccessSequence()
    {
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", levelLoadDelay);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    
    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }        
        SceneManager.LoadScene(nextSceneIndex);

    }
    void CrashSequence()
    {
        //!TODO Add crash SFX
        //!TODO add particle effect on crash
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", levelLoadDelay);
        

    }
}
