using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float yValue = 1.0f;    
    [SerializeField] float moveSpeed = 7f;
       
    // Start is called before the first frame update
    void Start()
    {
        PrintInstructions();
    }

    // Update is called once per frame
    void Update()
    {
        // Move Player Code 
        MovePlayer();
    }

    void MovePlayer()
    {
        // Move the Player character around 
        float xValue = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float zValue = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(xValue, yValue * Time.deltaTime, zValue);
    }

    void PrintInstructions()
    {
        Debug.Log("Use arrow keys to move around");
        Debug.Log("Colliding with objects with cost you points");
    }
}
