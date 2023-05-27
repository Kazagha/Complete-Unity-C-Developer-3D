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

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    Waypoint waypoint = null;

    private void Awake()
    {
        label = GetComponent<TextMeshPro>();
        waypoint = GetComponentInParent<Waypoint>();
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

        if(waypoint != null)
        {
            SetLabelColour();
        }

        ToggleLabels();
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
        if(waypoint.IsPlacable)
        {            
            label.color = defaultColour;
        }
        else
        {
            label.color = blockedColor;
        }
    }

    private void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);

        label.text = String.Format("{0},{1}", coordinates.x, coordinates.y);
    }

    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
