using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullets : MonoBehaviour
{


    void Update()
    {
        Destroy(gameObject, 2.0f);
    }

    void OnCollisionEnter(Collision collision)
    {

        Destroy(gameObject);

        if(collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemyBullet") || collision.gameObject.CompareTag("Leech"))
        {
            Destroy(collision.gameObject);
        }


    }
}
