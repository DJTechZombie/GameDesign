using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 10f;
    public float bulletForce = 1500;
    public int strength = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.forward *speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Debug.Log(other.name + " Hit!");
            Vector3 direction = transform.position - other.transform.position;
            direction.Normalize();
            direction.y = 0;
            other.GetComponent<Rigidbody>().AddForce(direction * bulletForce);
            //Destroy(other.gameObject, 2f);
            other.GetComponent<EnemyControl>().TakeDamage(strength);
        }
    }
}
