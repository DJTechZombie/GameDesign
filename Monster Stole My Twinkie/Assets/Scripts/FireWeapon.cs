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
            FireRay();
            GameObject spawnedBullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation); ;
            Destroy(spawnedBullet, 3f);

        }
    }

    private void FireRay()
    {
        Debug.DrawRay(bulletSpawn.transform.position, bulletSpawn.transform.forward *100, Color.red, 1f);
    }
}
