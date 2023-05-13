using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isPlacable;

    void OnMouseDown()
    {
        if (isPlacable)
        {
            Debug.Log(string.Format("Location: {0}", transform.name));
        }
    }    
}
