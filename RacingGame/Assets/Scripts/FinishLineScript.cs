using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishLineScript : MonoBehaviour
{
    public GameObject LapCompleteteTrig;
    public GameObject HalfLapTrig;

    public static int BestMinute;
    public static int BestSecond;
    public static float BestMilli;

    public Text BestMinuteDisplay;
    public Text BestSecondDisplay;
    public Text BestMilliDisplay;

    //public GameObject LapTimeBox;

    public LapTimeManager lapTime;

    private void OnTriggerEnter(Collider other)
    {
        BestMilli = LapTimeManager.MilliCount;
        BestSecond = LapTimeManager.SecondCount;
        BestMinute = LapTimeManager.MinuteCount;

        BestMilliDisplay.text = BestMilli.ToString("0");
        BestSecondDisplay.text = BestSecond.ToString("00") + ".";
        BestMinuteDisplay.text = BestMinute.ToString("00") + ":";

        LapCompleteteTrig.SetActive(false);
        HalfLapTrig.SetActive(true);
        LapTimeManager.ResetLapTime();
    }
}

