using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(0,1)] float movementFactor;
    [SerializeField] float period;
    [SerializeField] float offsetMultiplier;

    // Twice the value of Pi
    const float tau = Mathf.PI * 2;
    float cycles;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;// + (movementVector * offsetMultiplier);
    }

    // Update is called once per frame
    void Update()
    {
        
        //Stop moving if the Period is 0 or close to
        // Good idea not to compare floats with == 
        if(period <= Mathf.Epsilon) { return; }

        // Otherwise clamp in place 
        //period = Mathf.Clamp(period, .1f, 100f);

        // Calculate the offset and set the position 
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;

        // Continuall grows over time 
        cycles = (Time.time / period) + offsetMultiplier;
        // Calculate the position between -1 to 1 (radians) 
        float rawSinWave = Mathf.Sin(cycles * tau);

        // Use the +1 divide by 2 to show a range between 0 and 1
        movementFactor = (rawSinWave + 1f) / 2;
    }
}
