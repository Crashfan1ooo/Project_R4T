using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{

    public gunShoot gun;
    public SlowGauge slowAmount;

    private float ogBulletSpeed;
    public float nmeBSpeed = 2f; //Enemy Bullet Speed;
    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        ogBulletSpeed = nmeBSpeed;
        rb = gameObject.GetComponent<Rigidbody>();
        gun = (gunShoot)FindObjectOfType(typeof(gunShoot));
        slowAmount = (SlowGauge)FindObjectOfType(typeof(SlowGauge));
        //rb.AddForce(gameObject.transform.up * nmeBSpeed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(gameObject.transform.up * nmeBSpeed);
        Destroy(gameObject, 3.0f);

        if (Input.GetKeyDown(KeyCode.Mouse1) && slowAmount.currentSlow > 1)
        {
            nmeBSpeed = nmeBSpeed / 4; //slowSpeedDown;


        }
        if (Input.GetKeyUp(KeyCode.Mouse1) || slowAmount.currentSlow <= 1)
        {
            nmeBSpeed = ogBulletSpeed;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);


    }
}
