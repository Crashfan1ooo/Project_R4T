using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeechHunting : MonoBehaviour
{
    //like aggroCheck but for the leech

    public bool inRange;
    // Start is called before the first frame update
    void Start()
    {
        inRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Beigns chase
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "MainPlayer")
        {
            inRange = true;
        }
        
            
    }

    //Ends chase
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "MainPlayer")
        {
            inRange = false;
        }
    }
}
