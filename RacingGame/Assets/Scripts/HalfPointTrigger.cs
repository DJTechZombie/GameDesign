using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfPointTrigger : MonoBehaviour
{
    public GameObject[] Checkpoints;
    public GameObject checkpointTarget;
    public GameObject finishLine;

    [SerializeField]
    private int currentCheckpoint;

    private void Update()
    {
        checkpointTarget.transform.position = Checkpoints[currentCheckpoint].transform.position;
    }

    IEnumerator OnTriggerEnter(Collider other)
    {
        Debug.Log("Checkpoint entered by " + other.tag);
        if (other.tag == "Player")
        {
            this.GetComponent<SphereCollider>().enabled = false;
            currentCheckpoint++;
            if (currentCheckpoint >= Checkpoints.Length)
            {
                finishLine.SetActive(true);
                currentCheckpoint = 0;
            }
           
            yield return new WaitForSeconds(1);
            this.GetComponent<SphereCollider>().enabled = true;
        }
    }
}


