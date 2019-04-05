using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class findTarget : MonoBehaviour, IPooledObject
{
    private CarAIControl aiControl;
    public GameObject target;
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
        aiControl.m_Target = target.transform;
    }
}
