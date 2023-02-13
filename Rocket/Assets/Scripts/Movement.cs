using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb; 
    AudioSource audioSource;
    [SerializeField]float mainThrust = 1000f;
    [SerializeField] float rotateThrust = 100f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem rightParticles;
    [SerializeField] ParticleSystem leftParticles;
        [SerializeField] ParticleSystem thrustParticles;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
         ProcessThrust();
         ProcessRotation();        
    }


    void ProcessThrust() 
    {
    if (Input.GetKey(KeyCode.Space))
        {
            //Check out vector shortcuts up = 0, 1, 0
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);

            if(!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngine);
            } 
            if(!thrustParticles.isPlaying)
            {
                thrustParticles.Play();
            }
        } 
        else
        {
            audioSource.Stop();
            thrustParticles.Stop();
        }
    }


    void ProcessRotation()
    {
    if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(-rotateThrust);
            rightParticles.Play();
        } 
        else if(Input.GetKey(KeyCode.D))
        {
            ApplyRotation(rotateThrust);
            if(!leftParticles.isPlaying)
            {
                leftParticles.Play();
            }     
        }

    }
    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; //freezing rotation so we can manually rotate
    transform.Rotate(-Vector3.forward * rotationThisFrame * Time.deltaTime);
    rb.freezeRotation = false;
    }
    }