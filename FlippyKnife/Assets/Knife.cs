using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Knife : MonoBehaviour
{

    public Rigidbody rb;

    private Vector2 startSwipePos, stopSwipePos;

    public float force = 5f;
    public float torque = 0f;

    private float startswipeTime, stopSwipeTime;

    private float startTime;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetMouseButtonDown(0))
        {
            startSwipePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            startswipeTime = Time.time;
            startTime = Time.time;
        }
      if(Input.GetMouseButtonUp(0))
        {
            stopSwipePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            stopSwipeTime = Time.time;
            Swipe();
        }
    }

    void Swipe()
    {
        //if (rb.isKinematic == true)
       // {
            rb.isKinematic = false;
            Vector2 swipe = stopSwipePos - startSwipePos;
            float swipeForce;
            float swipetime = 1f - (stopSwipeTime - startswipeTime);
            if (swipetime > 0)
            {
                swipeForce = torque + (swipetime * 100);
            }
            else
            {
                swipeForce = 0.01f;
            }

            //Debug.Log(swipetime + "|" + swipeForce);
            rb.AddForce(swipe * force, ForceMode.Impulse);
            rb.AddTorque(0f, 0f, swipeForce, ForceMode.Impulse);
       // }
    }

    void OnCollisionEnter(Collision other)
    {
        float airTime = Time.time - startTime;
        if(rb.rotation.z <100)
        {
            if (!rb.isKinematic && airTime >= .1f)
            {
                Restart();
            }
        }

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Block")
        {
            rb.isKinematic = true;
            Debug.Log("HIT");
        }
        else
        {
            Restart();
        }
    }

   

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
