using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

public class FinishLineScript : MonoBehaviour
{
    public GameObject LapCompleteteTrig;
    public GameObject LapCompleteCam;
    public GameObject player;
    private CarAIControl playerAI;
    private CarUserControl playerControl;
    public Text finishText;

    //public GameObject LapTimeBox;

    public LapTimeManager lapTime;
    public LeadTracker leadTracker;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        { 
        LapCompleteteTrig.SetActive(false);
        lapTime.ResetLapTime();
        }

        if(lapTime.currentLap == 4)
        {
            LapCompleteCam.SetActive(true);
            playerAI = player.GetComponent<CarAIControl>();
            playerAI.enabled = true;
            playerControl = player.GetComponent<CarUserControl>();
            playerControl.enabled = false;

            if (leadTracker.leadCar == "Player")
            {
                finishText.text = "You Win!!";
            }
            else
            {
                finishText.text = "You Lose!!";
            }
            finishText.enabled = true;

        }
    }
}

