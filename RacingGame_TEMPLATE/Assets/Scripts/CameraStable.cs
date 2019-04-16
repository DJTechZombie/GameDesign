﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStable : MonoBehaviour
{

    public GameObject theCar;
    public float carX;
    public float carY;
    public float carZ;

    
    void Update()
    {
        carX = theCar.transform.eulerAngles.x;
        carY = theCar.transform.eulerAngles.y;
        carZ = theCar.transform.eulerAngles.z;

        transform.eulerAngles = new Vector3(carX - carX, carY, carZ-carZ);
    }
}
