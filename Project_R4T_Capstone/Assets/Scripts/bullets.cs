using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullets : MonoBehaviour
{


    void Update()
    {
        Destroy(gameObject, 2.0f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        Destroy(gameObject);

        if(collision.gameObject.CompareTag("Test Target") && gameObject.CompareTag("normalBullet"))
        {
            Destroy(collision.gameObject);
        }


        if (collision.gameObject.CompareTag("Test Target") && gameObject.CompareTag("slowBullet"))
        {
            collision.gameObject.GetComponent<targetMove>().speed = collision.gameObject.GetComponent<targetMove>().speed / 2;
        }
    }
}
