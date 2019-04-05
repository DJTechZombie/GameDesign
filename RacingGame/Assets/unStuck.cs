using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unStuck : MonoBehaviour
{
    [SerializeField]
    private Vector3 PrevMarker;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            transform.position = PrevMarker;
        }

        #region // Crude reset position


        /*if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            float x = this.gameObject.transform.position.x;
            float y = this.gameObject.transform.position.y;
            float z = this.gameObject.transform.position.z;
            this.gameObject.transform.position = new Vector3(x + 5, y + 5, z);
        }

        if(Input.GetKeyDown(KeyCode.Alpha9))
        {
            float x = this.gameObject.transform.position.x;
            float y = this.gameObject.transform.position.y;
            float z = this.gameObject.transform.position.z;
            this.gameObject.transform.position = new Vector3(x - 5, y + 5, z);

        }
        */
        #endregion
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PositionMarkers")
        {
            PrevMarker = other.transform.position;
        }
    }
}
