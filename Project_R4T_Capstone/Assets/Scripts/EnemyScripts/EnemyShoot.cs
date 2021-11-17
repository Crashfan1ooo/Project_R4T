using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    public gunShoot gun;
    public SlowGauge slowAmount;
    public Transform firePoint;

    public GameObject enemyBullet;

    float fireRate; // rate of fire
    float nextFire;

    public bool canShoot;
    // Start is called before the first frame update
    void Start()
    {
        fireRate = 0.5f;
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (canShoot == true)
        {
            checkSpeedFire();
        }
    }

    void checkSpeedFire()
    {
        if (Time.time > nextFire)
        {
            Instantiate(enemyBullet, firePoint.position, firePoint.rotation);

            nextFire = Time.time + fireRate;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("In Zone");
            canShoot = true;
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Outzone Zone");
            canShoot = false;
        }
    }
}
