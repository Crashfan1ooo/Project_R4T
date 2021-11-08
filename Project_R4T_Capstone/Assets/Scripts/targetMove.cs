using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetMove : MonoBehaviour
{
    public float ogSpeed;
    public float speed;
    public Vector3[] positions;

    private int index;
    // Start is called before the first frame update
    void Start()
    {
        
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

        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            speed  = speed / 2;
        }
        if(Input.GetKeyUp(KeyCode.Mouse1))
        {
            speed = ogSpeed;
        }
    }
}
