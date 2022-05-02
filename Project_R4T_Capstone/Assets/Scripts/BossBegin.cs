using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBegin : MonoBehaviour
{
    public Camera mCamera;
    public CameraDetach checkAdjuster;
    public GameObject thisCollider;
    public void Start()
    {
        mCamera = GameObject.Find("MainPlayer").transform.GetChild(0).GetComponent<Camera>();
    }

    void OnTriggerEnter(Collider BossBegins)
    {
        if (BossBegins.gameObject.CompareTag("Player"))
        {
            
            mCamera.transform.position = new Vector3(46, 10, -20);
            checkAdjuster.check = 1;
            Destroy(thisCollider);
        }
    }

}
