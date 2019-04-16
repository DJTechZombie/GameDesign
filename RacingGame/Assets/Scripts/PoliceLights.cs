using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceLights : MonoBehaviour
{
    [SerializeField]
    private Light redLight
        ;
    [SerializeField]
    private Light blueLight;


    private Vector3 redTemp;
    private Vector3 blueTemp;

    [SerializeField]
    private int speed;

    // Update is called once per frame
    void Update()
    {
        redTemp.y += speed * Time.deltaTime;
        blueTemp.y -= speed * Time.deltaTime;

        redLight.transform.eulerAngles = redTemp;
        blueLight.transform.eulerAngles = blueTemp;


    }
}
