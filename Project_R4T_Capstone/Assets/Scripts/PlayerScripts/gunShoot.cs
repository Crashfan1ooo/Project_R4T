using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunShoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public AudioSource bulletSound;
    public AudioSource slowTimeSoundFB;//Feedback for time slowing

    public float bulletSpeed = 20f;
    public float slowSpeed = 1f;



    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            shootGun();
            Debug.Log("Fire");
            bulletSound.Play();

        }

        //the sound for this section is for the audio to play when button is held and stop when button is stopped 
        if (Input.GetKeyDown(KeyCode.Mouse1)) //if holding down the button
        {

            Debug.Log("Time Is Being Slowed");
            if (!slowTimeSoundFB.isPlaying) // if sound is playing
            {
                slowTimeSoundFB.Play(); //play the sound
            }

        }
        if (Input.GetKeyUp(KeyCode.Mouse1)) //if button is let go stop playing sound
        {
            if(slowTimeSoundFB.isPlaying)
            {
                slowTimeSoundFB.Stop();

            }
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

