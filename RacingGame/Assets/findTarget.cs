using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;
using UnityStandardAssets.Utility;
using UnityEngine.AI;

public class findTarget : MonoBehaviour, IPooledObject
{
    private CarAIControl aiControl;
    public GameObject target;
    public WaypointProgressTracker aiCarScript;

    public string m_SpawnLane;
    // Start is called before the first frame update
    public void OnObjectSpawn(string spawnLane)
    {
        if(spawnLane == "SpawnLeft")
        {
            m_SpawnLane = "aiTarget_LeftLane";
        }
        else if(spawnLane == "SpawnMid")
        {
            m_SpawnLane = "aiTarget_MidLane";
        }
        else
        {
            m_SpawnLane = "aiTarget_RightLane";
        }
        aiControl = GetComponent<CarAIControl>();
        target = GameObject.FindGameObjectWithTag(m_SpawnLane);
        aiCarScript = GetComponent<WaypointProgressTracker>();
        if(aiCarScript == null)
        {
            Debug.Log("AI Script NOT Found");
        }
        aiCarScript.circuit = target.GetComponent<WaypointCircuit>();
        //aiControl.m_Target = target.transform;
    }
}
