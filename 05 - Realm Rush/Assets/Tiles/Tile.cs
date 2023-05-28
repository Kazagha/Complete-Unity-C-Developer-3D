using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] bool isPlacable;
    // Property used to access the isPlacable variable 
    public bool IsPlacable { get { return isPlacable; } }

    GridManager gridManager;
    Vector2Int coordinates = new Vector2Int();

    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
    }

    private void Start()
    {
        if(gridManager != null)
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);

            if(!isPlacable)
            {
                gridManager.BlockNode(coordinates);
            }
        }
    }

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
