using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class ActivateCop : MonoBehaviour
{

    [SerializeField]
    private CarAIControl copAI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            this.enabled = false;
            copAI.enabled = true;
        }
    }
}
