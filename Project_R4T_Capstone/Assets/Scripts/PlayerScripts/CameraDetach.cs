using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDetach : MonoBehaviour
{
    public int check = 0;
    public Camera thisCamera;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(check == 1)
        {
            CameraDechild();
        }
    }

    void CameraDechild()
    {
        transform.parent = null;
    }
}
