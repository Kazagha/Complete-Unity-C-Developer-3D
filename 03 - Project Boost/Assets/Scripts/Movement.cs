using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float thrustForce = 10f;
    [SerializeField] float torqueForce = 10f;
    [SerializeField] AudioClip thrustClip;
    [SerializeField] ParticleSystem thrustParticlesLeft;
    [SerializeField] ParticleSystem thrustParticlesRight;
    [SerializeField] ParticleSystem thrustParticlesMain;

    Rigidbody body;
    AudioSource audioSource;      
        
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
        EnableDebug();
    }

    void ProcessThrust ()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            StartThrust();
        }
        else
        {
            StopThrust();
        }
    }

    private void StopThrust()
    {
        audioSource.Stop();
        thrustParticlesMain.Stop();
    }

    private void StartThrust()
    {
        body.AddRelativeForce(Vector3.up * thrustForce * Time.deltaTime);
        PlayAudio();
        if (!thrustParticlesMain.isPlaying)
        {
            thrustParticlesMain.Play();
        }
    }

    void PlayAudio()
    {
        if(!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(thrustClip);
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            ApplyTorque(torqueForce);
          
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            ApplyTorque(-torqueForce);           
        }
        else
        {
            StopRotation();
        }
    }

    private void StopRotation()
    {
        body.AddRelativeTorque(0, 0, 0);
        thrustParticlesRight.Stop();
        thrustParticlesLeft.Stop();
    }

    private void ApplyTorque(float torque)
    {
        body.freezeRotation = true;
        transform.Rotate(Vector3.forward * torque * Time.deltaTime);
        //body.AddRelativeTorque(Vector3.forward * torque * Time.deltaTime);
        body.freezeRotation = false;

        if(torque > 0)
        {
            if(!thrustParticlesRight.isPlaying)
            {
                thrustParticlesRight.Play();
            }  
        }
        else
        {
            if(!thrustParticlesLeft.isPlaying)
            {
                thrustParticlesLeft.Play();
            } 
        }
    }

    void EnableDebug()
    {
        if (Input.GetKey(KeyCode.N))
        {   
            CollisionHandler coll = GetComponent<CollisionHandler>();
            coll.startSuccessSequence();
        }

        if (Input.GetKey(KeyCode.C))
        {
            // Disable collisions
        }
    }
}
