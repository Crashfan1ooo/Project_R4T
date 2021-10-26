using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunShoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject bulletSlowPrefab;
    public AudioSource bulletSound;

    public float bulletSpeed = 20f;



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
            shootSlow();
            Debug.Log("Slow Bullet Fired");

        }
    }

    void shootGun()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>();
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
    }

    void shootSlow()
    {
        GameObject bulletslow = Instantiate(bulletSlowPrefab, firePoint.position, firePoint.rotation);
        bulletslow.GetComponent<Rigidbody2D>();
        Rigidbody2D rb = bulletslow.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
    }
}

