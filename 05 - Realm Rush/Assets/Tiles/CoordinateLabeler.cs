using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColour = Color.white;
    [SerializeField] Color blockedColor = Color.grey;
    [SerializeField] Color exploredColor = Color.blue;
    [SerializeField] Color pathColor = new Color(1f, 0.5f, 0f);

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    GridManager gridManager;

    private void Awake()
    {
        label = GetComponent<TextMeshPro>();
        gridManager = FindObjectOfType<GridManager>();

        label.enabled = false;
        DisplayCoordinates();        
    }

    // Update is called once per frame
    void Update()
    {
        // Execute the script only in the designer 
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
        }

        SetLabelColour();       

        ToggleLabels();

        //UpdateObjectName();
    }

    void ToggleLabels()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();            
        }
    }

    private void SetLabelColour()
    {
        if(gridManager == null) { return; }

        Node node = gridManager.GetNode(coordinates);
        if(node == null) { return; }
        
        if(!node.isWalkable)
        {
            label.color = blockedColor;
        }
        else if (node.isPath)
        {
            label.color = pathColor;
        }
        else if(node.isExplored)
        {
            label.color = exploredColor;
        } 
        else 
        {
            label.color = defaultColour;
        }
    }

    private void DisplayCoordinates()
    {
        if(gridManager == null) { return; }
        
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / gridManager.UnityGridSize);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / gridManager.UnityGridSize);
        
        label.text = String.Format("{0},{1}", coordinates.x, coordinates.y);
    }

    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
