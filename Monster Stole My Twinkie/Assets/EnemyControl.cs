using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControl : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator anim;
    public Transform navPoint;

    [SerializeField]
    private int health = 1;
    [SerializeField]
    private int strength = 1;

    [SerializeField]
    private float AttackRange = 1f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(navPoint.position);
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(navPoint.position);
        if((transform.position - navPoint.position).magnitude <= AttackRange)
        {
            Attack();
        }
        else
        {
            anim.SetBool("isAttacking", false);
            anim.SetFloat("Speed", 1f);
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
            Destroy(gameObject,2f);
        }
        
    }
    
}