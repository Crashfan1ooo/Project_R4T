using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTarget : MonoBehaviour
{
    //not sure if this code is attached to anything
    float moveSpeed = 7f;

    //2D
    //Rigidbody2D rb;

    Rigidbody rb;
    public GameObject player;
    //2D

    Vector3 moveDirection;
    //Vector2 moveDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveDirection = (player.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 3f);
    }
}
