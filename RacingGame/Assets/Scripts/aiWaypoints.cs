using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aiWaypoints : MonoBehaviour
{
    public GameObject[] waypoints;
    public GameObject waypointTracker;
    [SerializeField]
    private int currentWaypoint;

    // Update is called once per frame
    void Update()
    {
        waypointTracker.transform.position = waypoints[currentWaypoint].transform.position;
        waypointTracker.transform.rotation = waypoints[currentWaypoint].transform.rotation;
    }

    private IEnumerator OnTriggerEnter(Collider other)
    {
        if(other.tag == "AIcar")
        {
            this.GetComponent<BoxCollider>().enabled = false;
            currentWaypoint++;
            if(currentWaypoint >= waypoints.Length)
            {
                Debug.Log("Reset Waypoints");
                currentWaypoint = 0;
            }
            else
            {
                Debug.Log("NextWaypoint");
            }
            yield return new WaitForSeconds(1);
            this.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
