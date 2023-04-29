using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Only show collision when colliding with the player            
        if(collision.gameObject.tag == "Player" & gameObject.tag != "Hit")
        {
            Debug.Log("Collision detected");

            // Change the colour on collision 
            MeshRenderer mesh = GetComponent<MeshRenderer>();
            mesh.material.color = Color.yellow;

            gameObject.tag = "Hit";
        }
    }
}
