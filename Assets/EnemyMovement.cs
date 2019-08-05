using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<Block> path;

    // Start is called before the first frame update
    void Start()
    {
        PrintAllWaypoints();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PrintAllWaypoints()
    {
        foreach (Block waypoint in path)
        {
            print(waypoint.name);
        }
    }
}
