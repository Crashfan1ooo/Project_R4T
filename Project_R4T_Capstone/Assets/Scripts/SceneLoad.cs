using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{


    //Loads the first Castle level
    void OnTriggerEnter(Collider ChangeScene)
    {
        if (ChangeScene.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(2);
        }
    }

    /*public void LoadGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }*/
}
