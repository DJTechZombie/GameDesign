using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float fireRate = 2f;

    private float nextFire;
    

    public void ShootWeapon()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject spawnedBullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation); ;
            Destroy(spawnedBullet, 3f);

        }
    }
}
