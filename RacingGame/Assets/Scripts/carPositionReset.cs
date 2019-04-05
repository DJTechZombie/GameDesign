using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class carPositionReset : MonoBehaviour
{
    public GameObject theCar;

    public aiWaypoints waypoints;
    [SerializeField]
    private Vector3 carPosition;
    [SerializeField]
    private Vector3 oldPosition;
    [SerializeField]
    private float PositionMagnitude;
    [SerializeField]
    private float currentTime;

    public CarAIControl aiControls;

    public float checkDelay = 5;
    public float lastCheckTime;

    // Start is called before the first frame update
    void Start()
    {
        waypoints = waypoints.GetComponent<aiWaypoints>();
        oldPosition = theCar.transform.position;
        lastCheckTime = Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        carPosition = theCar.transform.position;
        PositionMagnitude = (carPosition - oldPosition).magnitude;

        if (aiControls.isActiveAndEnabled)
        {
            currentTime += Time.deltaTime;
            if (currentTime - lastCheckTime > checkDelay)
            {
                //Debug.Log((carPosition - oldPosition).magnitude);
                if (PositionMagnitude < 1)
                {
                    if (waypoints.currentWaypoint > 0)
                    {
                        waypoints.currentWaypoint -= 1;
                    }
                    else
                    {
                        waypoints.currentWaypoint = 0;
                    }

                    theCar.transform.position = waypoints.waypointTracker.transform.position;
                }
                else
                {
                    Debug.Log("Checking new Position");
                    oldPosition = theCar.transform.position;
                }
                lastCheckTime = currentTime;
            }
        }
    }
}

