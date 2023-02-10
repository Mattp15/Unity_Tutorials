using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] AudioClip crash;
    [SerializeField] AudioClip success;
    AudioSource audioSource;
    
    bool isTransitioning = false;
     void Start() 
        {
            audioSource = GetComponent<AudioSource>();
        }
    
     void OnCollisionEnter(Collision other) 
    {
        if(isTransitioning) { return; }

        switch(other.gameObject.tag)
        {
            case "Finish":
                StartSuccessSequence();
                break;
            case "Friendly":
                break;
            case "Respawn":
                CrashSequence();
                break;
            default:
                break;
        }    
    }

    private void StartSuccessSequence()
    {
        audioSource.PlayOneShot(success);
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
        isTransitioning = true;
        audioSource.PlayOneShot(crash);
        //!TODO add particle effect on crash
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", levelLoadDelay);
        

    }
}
