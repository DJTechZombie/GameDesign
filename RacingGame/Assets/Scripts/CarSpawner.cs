using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField]
    private int spawnDelay = 1;
    [SerializeField]
    private float spawnTime = 0;
    private string spawnLane;

    private void Start()
    {
        spawnLane = this.tag;
        spawnDelay = Random.Range(0, 3);
        //carPooler.instance.SpawnFromPool("cars", transform.position, Quaternion.Euler(0, 180f, 0), spawnLane);
    }


    private void Update()

    {
        spawnTime += Time.deltaTime;
        if(spawnTime >= spawnDelay)
        {
//            Debug.Log("Spawning");
            carPooler.instance.SpawnFromPool("cars", transform.position, Quaternion.Euler(0,180f,0),spawnLane);
            spawnTime = 0;
            spawnDelay = Random.Range(5, 10);
        }
    }

}
