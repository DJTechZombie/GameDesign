using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfPointTrigger : MonoBehaviour
{
    public GameObject LapCompleteteTrig;
    public GameObject HalfLapTrig;


    private void OnTriggerEnter(Collider other)
    {
        LapCompleteteTrig.SetActive(true);
        HalfLapTrig.SetActive(false);
    }
}


