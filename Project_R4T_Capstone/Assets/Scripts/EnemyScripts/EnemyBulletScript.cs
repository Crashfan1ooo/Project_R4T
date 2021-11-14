using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{

    public gunShoot gun;
    public SlowGauge slowAmount;

    public float nmeBSpeed = 2f; //Enemy Bullet Speed;
    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        //rb.AddForce(gameObject.transform.up * nmeBSpeed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(gameObject.transform.up * nmeBSpeed);
        Destroy(gameObject, 3.0f);
    }
}
