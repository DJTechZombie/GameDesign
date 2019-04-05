using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiCarScript : MonoBehaviour
{

    public NavMeshAgent agent;
    public GameObject agentDesitnation;

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(agentDesitnation.transform.position);
    }
}
