using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    //Stuff pertaining to shooting
    public Rigidbody2D rb;
    public Camera cam;

    Vector2 mousePos;

    

    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);


    }

    void FixedUpdate()
    {
        Vector2 lookDir = mousePos - rb.position;

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

}
