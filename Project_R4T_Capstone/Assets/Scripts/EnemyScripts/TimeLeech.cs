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

    private bool isLeechin; //a bool to see if leech is active

    // Start is called before the first frame update
    void Start()
    {
        isLeechin = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.parent == null)
        {
            Debug.Log("No Parent Detected");
        }

        if (Input.GetKeyDown(KeyCode.Space) && Input.GetKeyDown(KeyCode.LeftShift))
        {

        }
    }

    
    void LeechDetatch() //DeParents the leech from the host
    {
        this.transform.parent = null;
    }


    //Thi code begins the draining if the leech is attached
    void LeechDrain()
    {
        //this is to make sure the game has the right object before draining the player of energy 
        if(isLeechin && gameObject.transform.parent.name =="MainPlayer" && gameObject.transform.parent.CompareTag("Player"))
        {

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
    }


}
