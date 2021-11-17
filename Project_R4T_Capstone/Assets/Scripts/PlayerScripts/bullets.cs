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

        if(collision.gameObject.CompareTag("Enemy") || gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(collision.gameObject);
        }


    }
}
