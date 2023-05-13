using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] float waitTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(printWaypointName());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator printWaypointName()
    {
        foreach(Waypoint waypoint in path)
        {
            //transform.position = new Vector3(waypoint.transform.position.x, 0f, waypoint.transform.position.z);            
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(waitTime);
        }
    }
}
