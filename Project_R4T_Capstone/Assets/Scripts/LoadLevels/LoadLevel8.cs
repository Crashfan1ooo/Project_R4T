using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel8 : MonoBehaviour
{
    //Loads level 8
    void OnTriggerEnter(Collider ChangeScene)
    {
        if (ChangeScene.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(9);
        }
    }
}
