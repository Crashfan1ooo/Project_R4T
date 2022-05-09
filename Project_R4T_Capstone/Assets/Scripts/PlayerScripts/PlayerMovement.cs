using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    public int health = 5;

    private bool isInvincible = false;
    private IEnumerator coroutine; 

    public Image[] HPTicks;


    public GameObject staminaBar;
    //private StaminaBar staminaBarMeter;
    //public TextMeshProUGUI healthText;
    public bool isDead = false;

    public AudioSource mouseHit;
    public AudioSource healthAccepted;

    // Start is called before the first frame update
    void Start()
    {
        originalSpeed = characterSpeed;
        controller = GetComponent<CharacterController>();
        coroutine = PlayerIsInvinicible(5.0f);
        //staminaBarMeter = staminaBar.GetComponent<StaminaBar>();

        //setHealthText();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Current gravity?" + directionY);

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));
        

        Vector3 direction = new Vector3(horizontalInput, 0, 0);

        if (controller.isGrounded)
        {

            directionY = 0.0f;
            direction.y = directionY;
            
            canDoubleJump = true;
            animator.SetBool("IsJumping", false);
            animator.SetBool("Landed", true);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                directionY = characterJump;
                animator.SetBool("IsJumping", true);
                animator.SetBool("Landed", false);
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

       

        if (Input.GetKeyDown(KeyCode.LeftShift) /*&& staminaBarMeter.currentStamina > 15*/)
        {
            
            //StaminaBar.UseStamina(15);
            characterSpeed = characterSpeed * 2;

        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) /* || staminaBarMeter.currentStamina <=15*/)
        {
            characterSpeed = originalSpeed;
        
        }
        /*if(staminaBarMeter.currentStamina <=15)
        {
            Debug.Log("Not enough stamina");
        }
        */
        directionY -= gravity * Time.deltaTime;
        direction.y = directionY;
        controller.Move(direction * characterSpeed * Time.deltaTime);

        

       switch(health)
       {
            case 5:
                HPTicks[4].gameObject.SetActive(true);
                HPTicks[3].gameObject.SetActive(true);
                HPTicks[2].gameObject.SetActive(true);
                HPTicks[1].gameObject.SetActive(true);
                HPTicks[0].gameObject.SetActive(true);
                break;

            case 4:
                HPTicks[4].gameObject.SetActive(false);
                HPTicks[3].gameObject.SetActive(true);
                HPTicks[2].gameObject.SetActive(true);
                HPTicks[1].gameObject.SetActive(true);
                HPTicks[0].gameObject.SetActive(true);
                break;


            case 3:
                HPTicks[4].gameObject.SetActive(false);
                HPTicks[3].gameObject.SetActive(false);
                HPTicks[2].gameObject.SetActive(true);
                HPTicks[1].gameObject.SetActive(true);
                HPTicks[0].gameObject.SetActive(true);
                break;

            case 2:
                HPTicks[4].gameObject.SetActive(false);
                HPTicks[3].gameObject.SetActive(false);
                HPTicks[2].gameObject.SetActive(false);
                HPTicks[1].gameObject.SetActive(true);
                HPTicks[0].gameObject.SetActive(true);
                break;

            case 1:
                HPTicks[4].gameObject.SetActive(false);
                HPTicks[3].gameObject.SetActive(false);
                HPTicks[2].gameObject.SetActive(false);
                HPTicks[1].gameObject.SetActive(false);
                HPTicks[0].gameObject.SetActive(true);
                break;

            case 0:
                HPTicks[4].gameObject.SetActive(false);
                HPTicks[3].gameObject.SetActive(false);
                HPTicks[2].gameObject.SetActive(false);
                HPTicks[1].gameObject.SetActive(false);
                HPTicks[0].gameObject.SetActive(false);
                Death();
                break;




       }


        Debug.Log(isInvincible);
       

        if(isDead == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
        animator.SetBool("Landed", true);

    }
    /*void setHealthText()
    {
        healthText.text = "Hit Points: " + health.ToString();
    }*/

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("EnemyBullet") || collision.collider.CompareTag("Enemy"))
        {
            if (isInvincible == false)
            {


                health = health - 1;
                mouseHit.Play();
                isInvincible = true;
                StartCoroutine(PlayerIsInvinicible(2.5f));
                //setHealthText();
            }
        }
    }

    private IEnumerator PlayerIsInvinicible(float WaitTime)
    {
        
        yield return new WaitForSeconds(WaitTime);
        isInvincible = false;
        
    }
        

    void Death()
    {
        if (health <= 0)
        {
            
            isDead = true;
            //Destroy(gameObject);
            //gameObject.SetActive(false);
        }


    }
}
