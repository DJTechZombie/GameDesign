using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportCars : MonoBehaviour
{

    public GameObject teleportTarget;

    private void OnTriggerEnter(Collider other)
    {
        other.transform.root.position = teleportTarget.transform.position;
        //other.transform.root.position = new Vector3(-4448.1f, -1.6f, 15436.4f);
    }
}
