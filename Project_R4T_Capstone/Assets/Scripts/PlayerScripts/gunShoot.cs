using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunShoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public AudioSource bulletSound;
    public AudioSource slowTimeSoundFB;//Feedback for time slowing

    public SlowGauge slowAmount;



    public float bulletSpeed = 20f;
    public float slowSpeed = 1f;


    private float rateOfire = 1f; //fire rate
    private float nextFire = 0f; //idk  anymore heres the reference i guess: https://www.youtube.com/watch?v=Kvd4Fnb9EPo 


    private void Start()
    {
        slowAmount = GameObject.Find("Canvas Variant").transform.GetChild(0).GetComponent<SlowGauge>();
    }

    void Update()
    {
        Debug.Log("rate of fire: " + Time.time + "next fire" + nextFire);
        //get slow gauge

        //SlowGauge slowAmount2 = GameObject.Find("SlowGuage").GetComponents<SlowGauge>();
        //GameObject.Find("SlowGauge").GetComponent<SlowGauge>();
        //gameObject.

        //Checks if game is paused to disable shooting
        if (!Pause.isPaused)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (Time.time > nextFire)
                {
                    nextFire = Time.time + rateOfire;

                    shootGun();
                    Debug.Log("Fire");
                    bulletSound.Play();
                    
                }
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
        if (Input.GetKeyUp(KeyCode.Mouse1) || slowAmount.currentSlow < 1) //if button is let go stop playing sound
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
            bullet.GetComponent<Rigidbody>();
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(firePoint.up * bulletSpeed, ForceMode.Impulse);

           
        }
       




        //This Code works with a rigidbody2D
        /*GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>();
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
        */
    }


    
}

