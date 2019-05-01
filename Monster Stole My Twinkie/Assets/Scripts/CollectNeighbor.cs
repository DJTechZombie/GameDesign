using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectNeighbor : MonoBehaviour
{
   
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("You Saved " + gameObject.name);
            Destroy(gameObject, .5f);
        }
    }
}
