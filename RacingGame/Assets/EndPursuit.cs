using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndPursuit : MonoBehaviour
{

    [SerializeField]
    private GameObject winText;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            winText.SetActive(true);
        }
    }
}
