using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAiming3D : MonoBehaviour
{
    public GameObject cannon; //place the "shootcube" here
    public Camera mainCam;
    private Vector3 target; //where the cannon should be looking

    //This code is for aiming the gun in 3D or Perspective Mode
    //reference code from https://www.youtube.com/watch?v=7-8nE9_FwWs

    private void Update()
    {
        //target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        //where the gun main corresponding to the main camera.
        target = mainCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));

        Vector3 difference = target - cannon.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        cannon.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
    }
}
