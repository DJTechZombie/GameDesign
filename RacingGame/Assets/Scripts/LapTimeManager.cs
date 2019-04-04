using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapTimeManager : MonoBehaviour
{
    public int MinuteCount;
    public int SecondCount;
    public float MilliCount;

    
    public int MinuteCountBest;
    public int SecondCountBest;
    public float MilliCountBest;

    private float laptimeTotal;
    [SerializeField]
    private float bestTimeTotal;

    public Text lapTime;
    public Text bestTime;

    public Text lapDisplay;
    public int totalLaps;
    public int currentLap = 1;

    public bool isCounting = false;


    private void Start()
    {
        MinuteCountBest = HighScores.MinBest;
        SecondCountBest = HighScores.SecBest;
        MilliCountBest = HighScores.MilliBest;
        bestTimeTotal = HighScores.TotalBest;

        bestTime.text = MinuteCountBest.ToString("00") + ":" + SecondCountBest.ToString("00") + "." + MilliCountBest.ToString("0");
    }

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
            lapDisplay.text = "Lap " + currentLap.ToString() + "/" + totalLaps.ToString(); ;
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
        currentLap++;
    }

    public void setBestTime()
    {
        if (bestTimeTotal < 10)
        {
            MinuteCountBest = MinuteCount;
            SecondCountBest = SecondCount;
            MilliCountBest = MilliCount;
            bestTimeTotal = laptimeTotal;
            Debug.Log("Initial High Score Set");
            PlayerPrefs.SetInt("MinSave", MinuteCountBest);
            PlayerPrefs.SetInt("SecSave", SecondCountBest);
            PlayerPrefs.SetFloat("MilliSave", MilliCountBest);
            PlayerPrefs.SetFloat("BestTotal", bestTimeTotal);
        }
        else if (laptimeTotal < bestTimeTotal)
        {
            MinuteCountBest = MinuteCount;
            SecondCountBest = SecondCount;
            MilliCountBest = MilliCount;
            bestTimeTotal = laptimeTotal;
            Debug.Log("New High Score");
            PlayerPrefs.SetInt("MinSave", MinuteCountBest);
            PlayerPrefs.SetInt("SecSave", SecondCountBest);
            PlayerPrefs.SetFloat("MilliSave", MilliCountBest);
            PlayerPrefs.SetFloat("BestTotal", bestTimeTotal);
        }

        bestTime.text = MinuteCountBest.ToString("00") + ":" + SecondCountBest.ToString("00") + "." + MilliCountBest.ToString("0");

    }

}
