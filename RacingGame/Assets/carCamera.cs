using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carCamera : MonoBehaviour
{

    public GameObject CameraMain;
    public GameObject FPcameraPOS;
    public GameObject rearCameraPOS;
   

    private int selectedCamera;



    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            CameraMain.gameObject.SetActive(true);
            FPcameraPOS.gameObject.SetActive(false);
            rearCameraPOS.gameObject.SetActive(false);
            selectedCamera = 0;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            FPcameraPOS.gameObject.SetActive(true);
            CameraMain.gameObject.SetActive(false);
            rearCameraPOS.gameObject.SetActive(false);
            selectedCamera = 1;
        }
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            rearCameraPOS.gameObject.SetActive(true);
            FPcameraPOS.gameObject.SetActive(false);
            CameraMain.gameObject.SetActive(false);
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            if(selectedCamera == 0)
            {
                CameraMain.gameObject.SetActive(true);
                FPcameraPOS.gameObject.SetActive(false);
                rearCameraPOS.gameObject.SetActive(false);

            }
            else if(selectedCamera ==1)
            {
                FPcameraPOS.gameObject.SetActive(true);
                CameraMain.gameObject.SetActive(false);
                rearCameraPOS.gameObject.SetActive(false);
            }
        }
    }
}
