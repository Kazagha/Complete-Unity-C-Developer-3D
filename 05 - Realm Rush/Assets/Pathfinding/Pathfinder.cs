using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Vector2Int startCoordinates;
    public Vector2Int StartCoordinates { get { return startCoordinates; } }
    [SerializeField] Vector2Int destinationCoordinates;
    public Vector2Int DestinationCoordinates { get { return destinationCoordinates; } }

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
            startNode = grid[startCoordinates];
            destinationNode = grid[destinationCoordinates];
        }        
    }

    void Start()
    {
        GetNewPath();
    }

    public List<Node> GetNewPath()
    {
        return GetNewPath(startCoordinates);
    }

    public List<Node> GetNewPath(Vector2Int coordinates)
    {
        gridManager.ResetNodes();
        BreadthFirstSearch(coordinates);
        return BuildPath();
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
                neighbour.connectedTo = currentSeachNode;
                reached.Add(neighbour.coordinates, neighbour);
                frontier.Enqueue(neighbour);
            }
        }
    }

    void BreadthFirstSearch(Vector2Int coordinates)
    {
        frontier.Clear();
        reached.Clear();
        
        // Allow the start and end nodes to be walkable for the Pathfinder
        // but not allow placement of towers 
        startNode.isWalkable = true;
        destinationNode.isWalkable = true;

        bool isRunning = true;

        // Add the starting coordinates to the frontier list 
        frontier.Enqueue(grid[coordinates]);
        // Add the starting coordinates to the 'reached' coordinates list 
        reached.Add(coordinates, grid[coordinates]);

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

    List<Node> BuildPath()
    {
        List<Node> path = new List<Node>();
        Node currentNode = destinationNode;

        path.Add(currentNode);
        currentNode.isPath = true;

        while(currentNode.connectedTo != null)
        {
            currentNode = currentNode.connectedTo;

            path.Add(currentNode);
            currentNode.isPath = true;
        }

        path.Reverse();

        return path;
    }

    public bool WillBlockPath(Vector2Int coordinates)
    {
        if(grid.ContainsKey(coordinates))
        {
            bool previousState = grid[coordinates].isWalkable;

            grid[coordinates].isWalkable = false;
            List<Node> newPath = GetNewPath();
            grid[coordinates].isWalkable = previousState;

            if(newPath.Count <= 1)
            {
                GetNewPath();
                return true; 
            }            
        }
        return false;
    }

    public void NotifyReceivers()
    {
        BroadcastMessage("RecalculatePath", false, SendMessageOptions.DontRequireReceiver);
    }
}
