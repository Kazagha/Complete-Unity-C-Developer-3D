using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColour = Color.white;
    [SerializeField] Color blockedColor = Color.grey;

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    [SerializeField] Waypoint waypoint = null;

    private void Awake()
    {
        label = GetComponent<TextMeshPro>();
        waypoint = GetComponentInParent<Waypoint>();
        DisplayCoordinates();
    }

    private void Start()
    {
        waypoint = GetComponentInParent<Waypoint>();
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
            //Debug.Log(label.color.ToString());
            ColorCoordinates();
        }
    }

    private void ColorCoordinates()
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
