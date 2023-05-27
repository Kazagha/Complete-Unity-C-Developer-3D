using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Node currentSeachNode;
    Vector2Int[] directions = { Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down };
    GridManager gridManager;
    Dictionary<Vector2Int, Node> grid;
    
    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();

        if(gridManager != null)
        {
            grid = gridManager.Grid;
        }
    }

    void Start()
    {
        exploreNeighbors();
    }

    private void exploreNeighbors()
    {
        foreach(Vector2Int direction in directions)
        {
            List<Node> neighbors = new List<Node>();

            Vector2Int connected_coord = currentSeachNode.coordinates + direction;

            // Check if the node exists
            //Node connected_node = gridManager.GetNode(connected_coord);
            //Debug.Log(String.Format("Checking... {0}", connected_coord));
            //if (connected_node != null)
            //{
                //neighbors.Add(connected_node);
            //}

            if(grid.ContainsKey(connected_coord))
            {
                neighbors.Add(grid[connected_coord]);

                //TODO: remove after testing 
                grid[connected_coord].isExplored = true;
                grid[currentSeachNode.coordinates].isPath = true;
            }
        }        
    }
}
