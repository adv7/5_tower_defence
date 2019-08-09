using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<Waypoint> path;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath()
    {
        // print("starting patrol");
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            // print("visiting block: " + waypoint);
            yield return new WaitForSeconds(1f);
        }
        // print("ending patrol");
    }
}
