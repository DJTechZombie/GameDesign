using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class Waypoints
{
    public Transform pos { get; set; }

}
    public class EnemyControl : MonoBehaviour
    {
    private NavMeshAgent agent;
    private Animator anim;
    [SerializeField]
    private string NavPointName;
    private Waypoints navPoint;
    private Waypoints lastWaypoint;

    [SerializeField]
    private int health = 1;
    [SerializeField]
    private int strength = 1;

    [SerializeField]
    private float AttackRange = 1f;

    public static List<Waypoints> waypoints = new List<Waypoints>();

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
    }

    void Start()
    {
        FindNearestWaypoint();
    }

    void Update()
    {
        agent.SetDestination(navPoint.pos.position);
        if (agent.remainingDistance > agent.stoppingDistance)
        {
            anim.SetFloat("Speed", (transform.position - navPoint.pos.position).normalized.magnitude);
        }
        else
        {
            lastWaypoint = navPoint;
            Debug.Log(name + ": Target Reached");
            FindNearestWaypoint();
        }
    }

    public void Attack()
    {
        anim.SetBool("isAttacking", true);
        Debug.Log("Enemy in attack range");
    }

    public void TakeDamage(int damage)
    {
        if (health > damage)
        {
            health -= damage;
        }
        else
        {
            anim.SetTrigger("Die");
            Destroy(gameObject, 3f);
        }
    }

    public static void AddWaypoint(Transform t)
    {
            waypoints.Add(new Waypoints() { pos = t });
    }

    private void FindNearestWaypoint()
    {
        float distToClosestWP = Mathf.Infinity;
        foreach(Waypoints wp in waypoints)
        {
            if (navPoint == null || wp != lastWaypoint)
            {
                float distToWP = (wp.pos.position - transform.position).sqrMagnitude;
                if (distToWP < distToClosestWP)
                {
                    distToClosestWP = distToWP;
                    navPoint = wp;
                    NavPointName = navPoint.pos.gameObject.name;
                }
            }
        }
    }
}