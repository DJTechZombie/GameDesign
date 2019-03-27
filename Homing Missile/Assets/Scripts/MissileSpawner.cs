using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSpawner : MonoBehaviour {

    public float spawnRate = 11f;
    public float spawnCountdown;
    public GameObject missile;
    public static bool canSpawn = true;


	// Use this for initialization
	void Start () {
        //spawn();
        spawnCountdown = 2f;
	}
	
	// Update is called once per frame
	void Update () {
		if(spawnCountdown <= 0 && canSpawn)
        {
            spawn();
            spawnRate /= 1.125f;
            spawnCountdown = spawnRate;
        }
        else
        {
            spawnCountdown -= Time.deltaTime;
        }
	}

    public void spawn()
    {
        Instantiate(missile, new Vector3(Random.Range(-18, 18), -2.45f, 0.0f), Quaternion.identity);
    }
}
