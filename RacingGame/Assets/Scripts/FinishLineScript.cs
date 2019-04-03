using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishLineScript : MonoBehaviour
{
    public GameObject LapCompleteteTrig;

    //public GameObject LapTimeBox;

    public LapTimeManager lapTime;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        { 
        LapCompleteteTrig.SetActive(false);
        lapTime.ResetLapTime();
        }
    }
}

