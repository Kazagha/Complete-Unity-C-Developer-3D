using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected");

        // Change the colour on collision 
        MeshRenderer mesh = GetComponent<MeshRenderer>();
        mesh.material.color = Color.yellow;
    }
}
