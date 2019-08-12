using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Waypoint startWaypont, endWaypoint;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    [SerializeField] bool isRunning = true; // todo make private

    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        ColorStartAndEnd();
        //ExploreNeighbours();
        Pathfind();
    }

    private void Pathfind()
    {
        queue.Enqueue(startWaypont);

        while (queue.Count > 0 && isRunning)
        {
            var searchCenter = queue.Dequeue();
            print("Searching from: " + searchCenter); // todo remove log
            HaltIfEndFound(searchCenter);
            ExploreNeighbours(searchCenter);
            searchCenter.isExplored = true;
        }

        // todo work-out path
        print("Finished pathfinding?");
    }

    private void HaltIfEndFound(Waypoint searchCenter)
    {
        if(searchCenter == endWaypoint)
        {
            print("Searching from end node, therefound stopped"); // todo remove log
            isRunning = false;
        }
    }

    private void ExploreNeighbours(Waypoint from)
    {
        if(!isRunning) { return; }

        foreach (Vector2Int direction in directions)
        {
            Vector2Int neigbourCoordinates = direction + from.GetGridPos();
            try
            {
                QueueNewNeighbours(neigbourCoordinates);
            }
            catch
            {
                // do nothing
            }
        }
    }

    private void QueueNewNeighbours(Vector2Int neigbourCoordinates)
    {
        Waypoint neighbour = grid[neigbourCoordinates];
        if(neighbour.isExplored)
        {
            // do nothing
        }
        else
        {
            neighbour.SetTopColor(Color.blue); // todo move later
            queue.Enqueue(neighbour);
            print("Queueing " + neighbour);
        }       
    }

    private void ColorStartAndEnd()
    {
        startWaypont.SetTopColor(Color.green);
        endWaypoint.SetTopColor(Color.red);
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach(Waypoint waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPos();
            if(grid.ContainsKey(gridPos))
            {
                Debug.LogWarning("Skipping overlapping block" + waypoint);
            }
            else
            {
                grid.Add(gridPos, waypoint);
            }
        }
    }
}
