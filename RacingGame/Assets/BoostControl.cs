using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostControl : MonoBehaviour
{

    public Rigidbody playerRB;
    public float boostSpeed = 50f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Boosting");
            playerRB.AddForce(transform.forward * boostSpeed, ForceMode.Acceleration);
        }
    }
}
