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
    private float ogFireRate;

    public bool canShoot;
    // Start is called before the first frame update
    void Start()
    {
        fireRate = 0.5f;
        ogFireRate = fireRate;
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (canShoot == true)
        {
            checkSpeedFire();
        }


        if (Input.GetKeyDown(KeyCode.Mouse1) && slowAmount.currentSlow > 1)
        {
            fireRate = fireRate * 4; //slowSpeedDown;
            Debug.Log(fireRate);

        }
        if (Input.GetKeyUp(KeyCode.Mouse1) || slowAmount.currentSlow <= 1)
        {
            fireRate = ogFireRate;
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
