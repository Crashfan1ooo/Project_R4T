using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetMove : MonoBehaviour
{
    public float ogSpeed;
    public float speed;
    public float slowSpeedDown = 5f; //when slowing the speed of something, the slow speed has to be a value or you will get infinity.;
    public Vector3[] positions;

    private int index;

    public gunShoot gun;
    public SlowGauge slowAmount;

    //Code for enemy
    public Transform player;
    public bool isEnemy;
    private Rigidbody2D rb;
    public EnemyShoot boolCheck;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        ogSpeed = speed;
        
    }

    // Update is called once per frame
    void Update()
    {
        //float ogSpeed = speed;
        
            transform.position = Vector2.MoveTowards(transform.position, positions[index], Time.deltaTime * speed);

        if( transform.position == positions[index])
        {
            if (index == positions.Length - 1)
            {
                index = 0;
            }
            else
            {
                index++;
            }
        }

        if(Input.GetKeyDown(KeyCode.Mouse1) && slowAmount.currentSlow > 1)
        {
           speed  = speed / slowSpeedDown;
         
            
        }
        if(Input.GetKeyUp(KeyCode.Mouse1) || slowAmount.currentSlow <= 1)
        {
            speed = ogSpeed;
        }

        if(isEnemy)
        {
            actLikeEnemy();
        }


    }

    public void actLikeEnemy()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg -90f;
        rb.rotation = angle;

    }
}
