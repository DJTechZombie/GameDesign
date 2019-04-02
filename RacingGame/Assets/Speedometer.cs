using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

public class Speedometer : MonoBehaviour
{
    public CarController carController;
    public Text speedText;
    
    // Update is called once per frame
    void Update()
    {
        speedText.text = carController.CurrentSpeed.ToString("000");
    }
}
