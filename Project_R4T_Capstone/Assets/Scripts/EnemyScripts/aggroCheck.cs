using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aggroCheck : MonoBehaviour
{

    public EnemyShoot boolCheck;
    
    
    // Start is called before the first frame update
    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
         if(other.gameObject.name == "shooterCube")
        {
            boolCheck.canShoot = true;
        }
    }
}
