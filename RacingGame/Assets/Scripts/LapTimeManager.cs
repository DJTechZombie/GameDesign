using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapTimeManager : MonoBehaviour
{
    public static int MinuteCount;
    public static int SecondCount;
    public static float MilliCount;

    public static int MinuteCountBest;
    public static int SecondCountBest;
    public static float MilliCountBest;

    private float laptimeTotal;
    private float bestTimeTotal;

    public Text lapTime;
    public Text bestTime;

    public bool isCounting = false;

    // Update is called once per frame
    void Update()
    {
        if (isCounting)
        {
            MilliCount += Time.deltaTime * 10;
            laptimeTotal += Time.deltaTime;

            if (MilliCount >= 10)
            {
                MilliCount = 0;
                SecondCount++;
            }
            if (SecondCount >= 60)
            {
                SecondCount = 0;
                MinuteCount++;
            }

            lapTime.text = MinuteCount.ToString("00") + ":" + SecondCount.ToString("00") + "." + MilliCount.ToString("0");
        }
    }

    public void ResetLapTime()
    {
        setBestTime();
        MinuteCount = 0;
        SecondCount = 0;
        MilliCount = 0;
        laptimeTotal = 0;
    }

    public void setBestTime()
    {
        if (MinuteCountBest == 0 && SecondCountBest == 0 && MilliCountBest == 0)
        {
            MinuteCountBest = MinuteCount;
            SecondCountBest = SecondCount;
            MilliCountBest = MilliCount;
            bestTimeTotal = laptimeTotal;
        }
        else if (laptimeTotal < bestTimeTotal)
        {
            MinuteCountBest = MinuteCount;
            SecondCountBest = SecondCount;
            MilliCountBest = MilliCount;
            bestTimeTotal = laptimeTotal;
        }

        bestTime.text = MinuteCountBest.ToString("00") + ":" + SecondCountBest.ToString("00") + "." + MilliCountBest.ToString("0");

    }

}
