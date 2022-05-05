using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPackPickUp : MonoBehaviour
{
    public GameObject player;

    [SerializeField] private Vector3 _rotation;
    [SerializeField] private float _speed;
    [SerializeField] private AudioSource healthPickUpSound;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("MainPlayer");
        healthPickUpSound = player.GetComponent<PlayerMovement>().healthAccepted;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(_rotation * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "MainPlayer")
        {
            other.gameObject.GetComponent<PlayerMovement>().health = 5;
            healthPickUpSound.Play();
            Destroy(this.gameObject);
            
        }
    }
}
