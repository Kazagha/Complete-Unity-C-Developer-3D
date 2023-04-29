using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDelay : MonoBehaviour
{
    [SerializeField] float fallDelay = 3;
    // Start is called before the first frame update
    Rigidbody body;
    MeshRenderer rend;
    
    void Start()
    {
        body = GetComponent<Rigidbody>();
        rend = GetComponent<MeshRenderer>();

        rend.enabled = false;
        body.useGravity = false;               
    }

    // Update is called once per frame
    void Update()
    {        
        if (Time.time > fallDelay)
        {
            rend.enabled = true;
            body.useGravity = true;
        }
    }
}
