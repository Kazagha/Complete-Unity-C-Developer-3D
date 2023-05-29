using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] [Range(0f,5f)] float speed = 1f;

    GridManager gridManager;
    Pathfinder pathfinder;
    List<Node> path = new List<Node>();
    Enemy enemy;

    private void OnEnable()
    {
        ReturnToStart();
        RecalculatePath(true);                
    }

    private void Awake()
    {
        pathfinder = FindObjectOfType<Pathfinder>();
        gridManager = FindObjectOfType<GridManager>();
        enemy = GetComponent<Enemy>();
    }

    void RecalculatePath(bool resetPath)
    {
        Vector2Int coordinates = new Vector2Int();
       
        if(resetPath)
        {
            coordinates = pathfinder.StartCoordinates;
        } 
        else
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);
        }

        StopAllCoroutines();
        path.Clear();
        path = pathfinder.GetNewPath(coordinates);
        StartCoroutine(FollowPath());
    }

    void ReturnToStart()
    {
        transform.position = gridManager.GetPositionfromCoordinates(pathfinder.StartCoordinates);
    }

    void FinishPath()
    {
        enemy.StealGold();
        gameObject.SetActive(false);     
    }

    IEnumerator FollowPath()
    {
        for(int i = 1; i < path.Count; i++)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = gridManager.GetPositionfromCoordinates(path[i].coordinates);
            float travelPercent = 0f;

            transform.LookAt(endPosition);

            while(travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }            
        }

        FinishPath();
    }
}
