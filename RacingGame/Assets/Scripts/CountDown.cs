using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

public class CountDown : MonoBehaviour
{

    public Text countdown;
    public AudioSource getReady;
    public AudioSource goAudio;

    public LapTimeManager lapTimer;
    public CarUserControl carControls;
    public CarAIControl aiControls;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountStart());
    }
    IEnumerator CountStart()
    {
        yield return new WaitForSeconds(.5f);
        countdown.text = "3";
        getReady.Play();
        countdown.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        countdown.gameObject.SetActive(false);
        countdown.text = "2";
        getReady.Play();
        countdown.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        countdown.gameObject.SetActive(false);
        countdown.text = "1";
        getReady.Play();
        countdown.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        countdown.gameObject.SetActive(false);
        goAudio.Play();
        lapTimer.isCounting = true;
        carControls.enabled = true;
        aiControls.enabled = true;
    }
}
