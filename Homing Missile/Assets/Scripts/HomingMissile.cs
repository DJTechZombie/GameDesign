using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HomingMissile : MonoBehaviour {

    public MissileSpawner missleSpawner;
    

    public Transform target;
    private GameObject myTarget;
	public float speed = 5f;
	public float rotateSpeed = 200f;
    public GameObject smallExplosion;
    public GameObject largeExplosion;
    private GameObject explosion;
    

	private Rigidbody2D rb;

    // Use this for initialization
    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        myTarget = target.gameObject;
        missleSpawner = FindObjectOfType<MissileSpawner>();
    }

    void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {
        if (myTarget == null)
        {
            target = GameObject.FindGameObjectWithTag("Target").transform;
            speed = 10f;
        }

		Vector2 direction = (Vector2)target.position - rb.position;

		direction.Normalize();

		float rotateAmount = Vector3.Cross(direction, transform.up).z;

		rb.angularVelocity = -rotateAmount * rotateSpeed;

		rb.velocity = transform.up * speed;

        }

    private void Update()
    {
        speed *= 1.0001f ;
        rotateSpeed *= 1.0001f;
    }

    void OnTriggerEnter2D(Collider2D other)
	{
        //Instantiate(smallExplosion, transform.position, transform.rotation);
        explosion = (GameObject)Instantiate(smallExplosion, transform.position, transform.rotation);
        Destroy(explosion, 1f);
		if(other.tag == "Player")
        {

            GameManager.lives -= 1;
            Destroy(gameObject);
            if(GameManager.lives == 0)
            
            {
                Instantiate(largeExplosion, transform.position, transform.rotation);
                Destroy(other.gameObject);
            }

        }
        else
            if(other.tag == "Enemy")
        {
            Destroy(gameObject);
        }

    }
}
