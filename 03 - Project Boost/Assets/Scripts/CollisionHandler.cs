using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.tag)
        {            
            case "Obstacle":
                Debug.Log("Collision Detected");
                break;
            case "Landing Pad":
                Debug.Log("Landing success");
                break;
            case "Ground":
                Debug.Log("Ground");
                break;
            case "Launch Pad":
                break;
            default:
                Debug.Log("Other Collision");
                break;
        }
    }
}
