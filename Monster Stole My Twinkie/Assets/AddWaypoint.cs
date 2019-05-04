using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddWaypoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EnemyControl.AddWaypoint(transform);
    }

}
