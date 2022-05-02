using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnds : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject thisCollider2;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.Find("MainPlayer").transform.GetChild(0).GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider BossEnds)
    {
        if (BossEnds.gameObject.CompareTag("Player"))
        {

            mainCamera.transform.position = new Vector3(46, 10, -20);
            //checkAdjuster.check = 1;
            Destroy(thisCollider2);
        }
    }
}
