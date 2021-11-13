using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunShoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public AudioSource bulletSound;

    public float bulletSpeed = 20f;
    public float slowSpeed = 1f;



    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            shootGun();
            Debug.Log("Fire");
            bulletSound.Play();

        }

        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            
            Debug.Log("Time Is Being Slowed");

        }
    }

    void shootGun()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>();
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
    }


}

