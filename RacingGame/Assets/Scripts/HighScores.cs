using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScores : MonoBehaviour
{
    public static int MinBest;
    public static int SecBest;
    public static float MilliBest;
    public static float TotalBest;

    // Start is called before the first frame update
    void Awake()
    {
        MinBest = PlayerPrefs.GetInt("MinSave");
        SecBest = PlayerPrefs.GetInt("SecSave");
        MilliBest = PlayerPrefs.GetFloat("MilliSave");
        TotalBest = PlayerPrefs.GetFloat("BestTotal");
    }

    
}
