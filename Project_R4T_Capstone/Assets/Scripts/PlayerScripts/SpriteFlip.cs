using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlip : MonoBehaviour
{
    //Component Varibles
    private CharacterController controller;

    //checks what direction the player is facing before flipping
    bool facingRight;

    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;
        controller = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        //Enables Player Movement
        float move = Input.GetAxis("Horizontal");


        if (move < 0 && facingRight)
        {
            Flip();
        }
        else if (move > 0 && !facingRight)
        {
            Flip();
        }
    }

    //Flips the player sprite to face the direction of movement
    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
