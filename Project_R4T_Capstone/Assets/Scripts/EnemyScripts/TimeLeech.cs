using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLeech : MonoBehaviour
{
    //this is the code for the time leech

    /*
     * The leech bounces around the map
     * When in the agro range it launches towards the player
     * If the entertrigger is accepted then the leech is parented to the player
     * When attached to player drain of time slow energy
     * Player must shift + jump to get the leech off of them
     */

    [SerializeField] public bool isLeechin; //a bool to see if leech is active

    [SerializeField] public SlowGauge timeDrain; //this variable is to connect the the gauge and allow the leech to drain

    public Transform targetPlayer; //this is to get the leech to move toward the player

    public float leechSpeed; //speed of the leech
    private float ogLeechSpeed; //original speed 

    public bool beginHunt; // same as inRange

    private Vector2 movement;

    private Rigidbody rb;
    //public Transform player; // this allows the leech to get the player position
    // Start is called before the first frame update
    void Start()
    {
        isLeechin = false;
        //targetPlayer = GameObject.Find("MainPlayer");
        timeDrain = GameObject.Find("Canvas").transform.GetChild(2).GetComponent<SlowGauge>();
        rb = this.GetComponent<Rigidbody>();
        ogLeechSpeed = leechSpeed;


    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("time drain is " + timeDrain);
        //to see if theres a parent
        if(this.transform.parent == null)
        {
            Debug.Log("No Parent Detected");
        }
        Debug.Log("Parent" + this.transform.parent);


        //to get leech off player
        if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.LeftShift))
        {
            LeechDetatch(); 

        }

        
        LeechDrain();
        StartLeechMove();


        if (Input.GetKeyDown(KeyCode.Mouse1) && timeDrain.currentSlow > 1)
        {
            leechSpeed = leechSpeed / 4;
        }

        if (Input.GetKeyUp(KeyCode.Mouse1) || timeDrain.currentSlow <= 1)
        {
            leechSpeed = ogLeechSpeed;
        }
    }



    void LeechDetatch() //DeParents the leech from the host
    {
        this.transform.parent = null;
        //this.transform.Translate(new Vector3(-5, 0, 0) * Time.deltaTime);
        isLeechin = false;
        this.gameObject.GetComponent<CapsuleCollider>().isTrigger = false;
    }


    //Thi code begins the draining if the leech is attached
    void LeechDrain()
    {
        //this is to make sure the game has the right object before draining the player of energy 
        if(isLeechin && gameObject.transform.parent.name =="MainPlayer" && gameObject.transform.parent.CompareTag("Player"))
        {
            //sucks the player of the time slow
            timeDrain.UseSlow(0.05f);
        }
    }

    
  
    
    private void OnTriggerEnter(Collider other)
    {
        //test to see if collision happens
        Debug.Log("Made contact with" + other.gameObject);
        //runs if object is turned into trigger
        if(this.gameObject.GetComponent<CapsuleCollider>().isTrigger == true)
        {
            
            if (other.gameObject.name == "MainPlayer" && other.gameObject.CompareTag("Player")) //should only attach to player
            {
                GameObject mainplayer = other.gameObject;
                this.transform.parent = mainplayer.transform; // is parented to the player
                isLeechin = true;

            }
        }

        //code to interact with bullet
        if(other.gameObject.CompareTag("normalBullet"))
        {
            this.GetComponent<CapsuleCollider>().isTrigger = false;
            Destroy(this);
            Destroy(other.gameObject);
        }
    }
    

    void StartLeechMove()
    {


        //connects bools to inRange to see if true or false
         beginHunt = gameObject.transform.GetChild(0).GetComponent<LeechHunting>().inRange;

        if(!beginHunt)
        {
            Debug.Log("The hunt is not started");
            this.gameObject.GetComponent<CapsuleCollider>().isTrigger = false;

        }
        else
        {
            Debug.Log("Hunt Begins");
            LeechMove();
            this.gameObject.GetComponent<CapsuleCollider>().isTrigger = true;
            //this.gameObject.transform.Translate(this.transform.position.x, this.transform.position.y, 0);

        }


    }

    void LeechMove()
    {
        Vector3 direction = targetPlayer.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 0f;
        rb.transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);
        direction.Normalize();
        movement = direction;


        rb.MovePosition(transform.position + (direction * leechSpeed * Time.deltaTime));
       
        
    }

    
}
