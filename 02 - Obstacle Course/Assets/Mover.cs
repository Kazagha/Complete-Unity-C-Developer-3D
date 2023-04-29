using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    //[SerializeField] float xValue = 0.0f;
    [SerializeField] float yValue = 1.0f;
    //[SerializeField] float zValue = 0.0f;
    // Start is called before the first frame update
    [SerializeField] float moveSpeed = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xValue = Input.GetAxis("Horizontal");
        float zValue = Input.GetAxis("Vertical");
        transform.Translate(xValue * moveSpeed * Time.deltaTime, yValue * Time.deltaTime, zValue * moveSpeed * Time.deltaTime);
    }
}
