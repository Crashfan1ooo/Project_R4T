using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    public Animator animator; 

    [SerializeField] public float characterSpeed = 12f;
    [SerializeField] public float characterJump = 3f;
    [SerializeField] private float gravity = 8f;
    [SerializeField] private float doubleJumpMultiplier = 0.5f;
    private float originalSpeed;

    private float directionY;
    private bool canDoubleJump = false;
    public bool isSprinting = false;

    public GameObject staminaBar;
    private StaminaBar staminaBarMeter;

    // Start is called before the first frame update
    void Start()
    {
        originalSpeed = characterSpeed;
        controller = GetComponent<CharacterController>();
        staminaBarMeter = staminaBar.GetComponent<StaminaBar>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));

        Vector3 direction = new Vector3(horizontalInput, 0, 0);

        if (controller.isGrounded)
        {
            canDoubleJump = true;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                directionY = characterJump;
            }

        }
        else
        {
            if(Input.GetKeyDown(KeyCode.Space) && canDoubleJump)
            {
                directionY = characterJump * doubleJumpMultiplier;
                canDoubleJump = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {

            StaminaBar.instance.UseStamina(15);
            characterSpeed = characterSpeed * 2;

        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            characterSpeed = originalSpeed;
        
        }

        directionY -= gravity * Time.deltaTime;
        direction.y = directionY;
        controller.Move(direction * characterSpeed * Time.deltaTime);

       
    }

}
