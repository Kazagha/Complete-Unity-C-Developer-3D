using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] InputAction movement;       
    [SerializeField] float xSpeed  = 50f;
    [SerializeField] float ySpeed = 50f;

    float xRange = 10f;
    float yRange = 5.5f; 
    Vector3 newPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        movement.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        float xThrow = movement.ReadValue<Vector2>().x;
        float yThrow = movement.ReadValue<Vector2>().y;
        
        newPos = new Vector3(
            Mathf.Clamp(transform.localPosition.x + (Time.deltaTime * xThrow * xSpeed),-xRange,xRange),
            Mathf.Clamp(transform.localPosition.y + (Time.deltaTime * yThrow * ySpeed),-yRange, yRange),            
            transform.localPosition.z
            );

        transform.localPosition = newPos;
    }
}
