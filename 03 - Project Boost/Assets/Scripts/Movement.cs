using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody body;

    [SerializeField] float thrustForce = 10f;
    [SerializeField] float torqueForce = 10f;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();         
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();         
    }

    void ProcessThrust ()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            body.AddRelativeForce(Vector3.up * thrustForce * Time.deltaTime);
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
}
