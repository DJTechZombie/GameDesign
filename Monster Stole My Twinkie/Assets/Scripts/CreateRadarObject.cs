using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateRadarObject : MonoBehaviour
{
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        Radar.RegisterRadarObject(this.gameObject, image);
    }

    private void OnDestroy()
    {
        Radar.RemoveRadarObject(this.gameObject);
    }

}
