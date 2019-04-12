using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuitTimer : MonoBehaviour
{

    public float timer = 160f;


    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            Debug.Log("Game Over");
        }
        
    }
}
