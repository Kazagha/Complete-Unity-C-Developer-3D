using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] GameObject towerPrefab;
    [SerializeField] bool isPlacable;    

    void OnMouseDown()
    {
        // Check if this is a valid loaction to place a tower 
        if (isPlacable)
        {
            //Debug.Log(string.Format("Location: {0}", transform.name));
            Instantiate(towerPrefab, transform.position, Quaternion.identity);
            isPlacable = false;
        }
    }    
}
