using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;

    [SerializeField] bool isPlacable;    
    // Property used to access the isPlacable variable 
    public bool IsPlacable {  get { return isPlacable;  } }

    void OnMouseDown()
    {
        // Check if this is a valid loaction to place a tower 
        if (isPlacable)
        {
            bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);
            //Instantiate(towerPrefab, transform.position, Quaternion.identity);
            isPlacable = !isPlaced;
        }
    }    
}
