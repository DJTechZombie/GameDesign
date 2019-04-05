using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeadTracker : MonoBehaviour
{
    public GameObject[] waypoints;
    public GameObject waypointTracker;
    public string leadCar;
    public Text racePositionText;

    public int currentWaypoint;

    // Update is called once per frame
    void Update()
    {
        waypointTracker.transform.position = waypoints[currentWaypoint].transform.position;
        waypointTracker.transform.rotation = waypoints[currentWaypoint].transform.rotation;
    }

    private IEnumerator OnTriggerEnter(Collider other)
    {
        leadCar = other.transform.root.name;
            this.GetComponent<BoxCollider>().enabled = false;
            currentWaypoint++;
            if (currentWaypoint >= waypoints.Length)
            {
                Debug.Log("Reset Waypoints");
                currentWaypoint = 0;
            }
            else
            {
            Debug.Log(other.transform.root.tag + " leading");
            }
            yield return new WaitForSeconds(1);
            this.GetComponent<BoxCollider>().enabled = true;
        if (leadCar == "PlayerCar")
        {
            racePositionText.text = "1st Place";
        }
        else
        {
            racePositionText.text = "2nd Place";
        }
    }
}