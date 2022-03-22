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

    // Start is called before the first frame update
    void Start()
    {
        isLeechin = false; 
    }

    // Update is called once per frame
    void Update()
    {
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

        //drains
        LeechDrain();
    }

    
    void LeechDetatch() //DeParents the leech from the host
    {
        this.transform.parent = null;
        //this.transform.Translate(new Vector3(-5, 0, 0) * Time.deltaTime);
        isLeechin = false;
    }


    //Thi code begins the draining if the leech is attached
    void LeechDrain()
    {
        //this is to make sure the game has the right object before draining the player of energy 
        if(isLeechin && gameObject.transform.parent.name =="MainPlayer" && gameObject.transform.parent.CompareTag("Player"))
        {
            //sucks the player of the time slow
            timeDrain.UseSlow(0.1f);
        }
    }

    /*
    void onCollisionEnter(Collision collision )
    {
        Debug.Log("Made contact with" + collision.gameObject);
        if(collision.gameObject.name == "MainPlayer" && collision.gameObject.CompareTag("Player")) //should only attach to player
        {
            GameObject mainplayer = collision.gameObject;
            this.transform.parent = mainplayer.transform; // is parented to the player
        }
    }
    */
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Made contact with" + other.gameObject);
        if (other.gameObject.name == "MainPlayer" && other.gameObject.CompareTag("Player")) //should only attach to player
        {
            GameObject mainplayer = other.gameObject;
            this.transform.parent = mainplayer.transform; // is parented to the player
            isLeechin = true;

        }

        if(other.gameObject.CompareTag("normalBullet"))
        {
            Destroy(this.gameObject);
        }
    }




}
