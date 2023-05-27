using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Vector2Int startCoordinates;
    [SerializeField] Vector2Int destinationCoordinates;

    Node startNode;
    Node destinationNode;
    Node currentSeachNode;

    Queue<Node> frontier = new Queue<Node>();
    Dictionary<Vector2Int, Node> reached = new Dictionary<Vector2Int, Node>();

    Vector2Int[] directions = { Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down };
    GridManager gridManager;
    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();
    
    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();

        if(gridManager != null)
        {
            grid = gridManager.Grid;
        }

        startNode = new Node(startCoordinates,true);
        destinationNode = new Node(destinationCoordinates, true);
        
    }

    void Start()
    {
        BreadthFirstSearch();
    }

    private void exploreNeighbors()
    {
        List<Node> neighbors = new List<Node>();

        foreach (Vector2Int direction in directions)
        {            
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
            }
        }    
        
        foreach (Node neighbour in neighbors)
        {
            if(!reached.ContainsKey(neighbour.coordinates) && neighbour.isWalkable)
            {
                reached.Add(neighbour.coordinates, neighbour);
                frontier.Enqueue(neighbour);
            }
        }
    }

    void BreadthFirstSearch()
    {
        bool isRunning = true;

        // Add the starting coordinates to the frontier list 
        frontier.Enqueue(startNode);
        // Add the starting coordinates to the 'reached' coordinates list 
        reached.Add(startCoordinates, startNode);

        while(frontier.Count > 0 && isRunning)
        {
            currentSeachNode = frontier.Dequeue();
            currentSeachNode.isExplored = true;
            exploreNeighbors();
            if(currentSeachNode.coordinates == destinationCoordinates)
            {
                isRunning = false;
            }
        }
    }
}