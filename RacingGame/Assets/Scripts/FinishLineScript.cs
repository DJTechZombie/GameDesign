using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishLineScript : MonoBehaviour
{
    public GameObject LapCompleteteTrig;
    public GameObject HalfLapTrig;

    //public GameObject LapTimeBox;

    public LapTimeManager lapTime;

    private void OnTriggerEnter(Collider other)
    {
        LapCompleteteTrig.SetActive(false);
        HalfLapTrig.SetActive(true);
        lapTime.ResetLapTime();
    }
}

