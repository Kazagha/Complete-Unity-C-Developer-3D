using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float thrustForce = 10f;
    [SerializeField] float torqueForce = 10f;
    [SerializeField] AudioClip thrustClip;

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
        loadNextLevel();
    }

    void ProcessThrust ()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            body.AddRelativeForce(Vector3.up * thrustForce * Time.deltaTime);
            PlayAudio();
        }
        else
        {
            audioSource.Stop();
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
            body.AddRelativeTorque(0, 0, 0);
        }
    }

    private void ApplyTorque(float torque)
    {
        body.freezeRotation = true;
        transform.Rotate(Vector3.forward * torque * Time.deltaTime);
        //body.AddRelativeTorque(Vector3.forward * torque * Time.deltaTime);
        body.freezeRotation = false;
    }

    void loadNextLevel()
    {
        if (Input.GetKey(KeyCode.N))
        {   
            CollisionHandler coll = GetComponent<CollisionHandler>();
            coll.startSuccessSequence();
        }
    }
}
