using System.IO;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private path path;
    [SerializeField] private float speed = 10f;
    [SerializeField] private int nextWaypointIndex = 1;
    [SerializeField] private float reachedWaypointClearance = 0.25f;

    private void Awake()
    {
        path = FindAnyObjectByType<path>();
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.position = path.waypoints[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, path.waypoints[nextWaypointIndex].position, Time.deltaTime * speed * 2);
        if (Vector3.Distance(transform.position, path.waypoints[nextWaypointIndex].position) <= reachedWaypointClearance)
        {
            nextWaypointIndex++;
            if (nextWaypointIndex >= path.waypoints.Length)
            {
                nextWaypointIndex = 0;
            }
        }
    }
}
