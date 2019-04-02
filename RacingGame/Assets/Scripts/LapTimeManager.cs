using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapTimeManager : MonoBehaviour
{
    public static int MinuteCount;
    public static int SecondCount;
    public static float MilliCount;
 
    public Text MinuteBox;
    public Text SecondBox;
    public Text MilliBox;

    // Update is called once per frame
    void Update()
    {
        MilliCount += Time.deltaTime * 10;


        if(MilliCount >= 10)
        {
            MilliCount = 0;
            SecondCount += 1;
        }
        if(SecondCount >=60)
        {
            SecondCount = 0;
            MinuteCount += 1;
        }

        MilliBox.text = MilliCount.ToString("0");
        SecondBox.text = SecondCount.ToString("00")+".";
        MinuteBox.text = MinuteCount.ToString("00")+":";

    }

    public static void ResetLapTime()
    {
        MinuteCount = 0;
        SecondCount = 0;
        MilliCount = 0;
    }
}
