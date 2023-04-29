using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    int hitCount = 0;
     
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Hit")
        {
            hitCount += 1;
            Debug.Log("The player has collided " + hitCount + " times");
        }
    }
}
