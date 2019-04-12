using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class Pursuit01_Scene : MonoBehaviour
{
    [SerializeField]
    private GameObject cam1;
    [SerializeField]
    private GameObject cam2;
    [SerializeField]
    private GameObject cam3;
    [SerializeField]
    private CarUserControl carControl;
    [SerializeField]
    private CarAIControl aiControl;
    [SerializeField]
    private CarAIControl enemyAiControl;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TheSequence());
    }

    IEnumerator TheSequence()
    {
        yield return new WaitForSeconds(5);
        aiControl.enabled = true;
        enemyAiControl.enabled = true;
        yield return new WaitForSeconds(1);
        cam2.SetActive(true);
        cam1.SetActive(false);
        yield return new WaitForSeconds(4);
        cam3.SetActive(true);
        cam2.SetActive(false);
        yield return new WaitForSeconds(2);
        aiControl.enabled = false;
        carControl.enabled = true;
    }

}
