using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    //public Slider staminaBar;

    private int maxStamina = 120;
    public float currentStamina;

    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine regen;

    public static StaminaBar instance;

    public GameObject thePlayer;
    private PlayerMovement thePlayerMovement;

    public Image[] STTicks;

    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {

        thePlayerMovement = thePlayer.GetComponent<PlayerMovement>();

        currentStamina = maxStamina;
        //staminaBar.maxValue = maxStamina;
        //staminaBar.value = maxStamina;
    }


    void Update()
    {
        if (currentStamina > 15)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                
                
                    UseStamina(0.20f);
                
                    
            }
            else if (currentStamina <= 15)
            {
                //staminaBar.value = currentStamina;
            }
        }


                
        if (currentStamina >= 120)
        {
            STTicks[11].gameObject.SetActive(true);
            STTicks[10].gameObject.SetActive(true);
            STTicks[9].gameObject.SetActive(true);
            STTicks[8].gameObject.SetActive(true);
            STTicks[7].gameObject.SetActive(true);
            STTicks[6].gameObject.SetActive(true);
            STTicks[5].gameObject.SetActive(true);
            STTicks[4].gameObject.SetActive(true);
            STTicks[3].gameObject.SetActive(true);
            STTicks[2].gameObject.SetActive(true);
            STTicks[1].gameObject.SetActive(true);
            STTicks[0].gameObject.SetActive(true);
        }
        else if (currentStamina < 120 && currentStamina >= 111)
        {
            STTicks[11].gameObject.SetActive(false);
            STTicks[10].gameObject.SetActive(true);
            STTicks[9].gameObject.SetActive(true);
            STTicks[8].gameObject.SetActive(true);
            STTicks[7].gameObject.SetActive(true);
            STTicks[6].gameObject.SetActive(true);
            STTicks[5].gameObject.SetActive(true);
            STTicks[4].gameObject.SetActive(true);
            STTicks[3].gameObject.SetActive(true);
            STTicks[2].gameObject.SetActive(true);
            STTicks[1].gameObject.SetActive(true);
            STTicks[0].gameObject.SetActive(true);
        }
        else if(currentStamina < 111 && currentStamina>= 101)
        {
            STTicks[11].gameObject.SetActive(false);
            STTicks[10].gameObject.SetActive(false);
            STTicks[9].gameObject.SetActive(true);
            STTicks[8].gameObject.SetActive(true);
            STTicks[7].gameObject.SetActive(true);
            STTicks[6].gameObject.SetActive(true);
            STTicks[5].gameObject.SetActive(true);
            STTicks[4].gameObject.SetActive(true);
            STTicks[3].gameObject.SetActive(true);
            STTicks[2].gameObject.SetActive(true);
            STTicks[1].gameObject.SetActive(true);
            STTicks[0].gameObject.SetActive(true);
        }
        else if(currentStamina < 101 && currentStamina >= 91)
        {
            STTicks[11].gameObject.SetActive(false);
            STTicks[10].gameObject.SetActive(false);
            STTicks[9].gameObject.SetActive(false);
            STTicks[8].gameObject.SetActive(true);
            STTicks[7].gameObject.SetActive(true);
            STTicks[6].gameObject.SetActive(true);
            STTicks[5].gameObject.SetActive(true);
            STTicks[4].gameObject.SetActive(true);
            STTicks[3].gameObject.SetActive(true);
            STTicks[2].gameObject.SetActive(true);
            STTicks[1].gameObject.SetActive(true);
            STTicks[0].gameObject.SetActive(true);
        }
        else if (currentStamina < 91 && currentStamina >= 81)
        {
            STTicks[11].gameObject.SetActive(false);
            STTicks[10].gameObject.SetActive(false);
            STTicks[9].gameObject.SetActive(false);
            STTicks[8].gameObject.SetActive(false);
            STTicks[7].gameObject.SetActive(true);
            STTicks[6].gameObject.SetActive(true);
            STTicks[5].gameObject.SetActive(true);
            STTicks[4].gameObject.SetActive(true);
            STTicks[3].gameObject.SetActive(true);
            STTicks[2].gameObject.SetActive(true);
            STTicks[1].gameObject.SetActive(true);
            STTicks[0].gameObject.SetActive(true);
        }
        else if (currentStamina < 81 && currentStamina >= 71)
        {
            STTicks[11].gameObject.SetActive(false);
            STTicks[10].gameObject.SetActive(false);
            STTicks[9].gameObject.SetActive(false);
            STTicks[8].gameObject.SetActive(false);
            STTicks[7].gameObject.SetActive(false);
            STTicks[6].gameObject.SetActive(true);
            STTicks[5].gameObject.SetActive(true);
            STTicks[4].gameObject.SetActive(true);
            STTicks[3].gameObject.SetActive(true);
            STTicks[2].gameObject.SetActive(true);
            STTicks[1].gameObject.SetActive(true);
            STTicks[0].gameObject.SetActive(true);
        }
        else if (currentStamina < 71 && currentStamina >= 61)
        {
            STTicks[11].gameObject.SetActive(false);
            STTicks[10].gameObject.SetActive(false);
            STTicks[9].gameObject.SetActive(false);
            STTicks[8].gameObject.SetActive(false);
            STTicks[7].gameObject.SetActive(false);
            STTicks[6].gameObject.SetActive(false);
            STTicks[5].gameObject.SetActive(true);
            STTicks[4].gameObject.SetActive(true);
            STTicks[3].gameObject.SetActive(true);
            STTicks[2].gameObject.SetActive(true);
            STTicks[1].gameObject.SetActive(true);
            STTicks[0].gameObject.SetActive(true);
        }
        else if (currentStamina < 61 && currentStamina >= 51)
        {
            STTicks[11].gameObject.SetActive(false);
            STTicks[10].gameObject.SetActive(false);
            STTicks[9].gameObject.SetActive(false);
            STTicks[8].gameObject.SetActive(false);
            STTicks[7].gameObject.SetActive(false);
            STTicks[6].gameObject.SetActive(false);
            STTicks[5].gameObject.SetActive(false);
            STTicks[4].gameObject.SetActive(true);
            STTicks[3].gameObject.SetActive(true);
            STTicks[2].gameObject.SetActive(true);
            STTicks[1].gameObject.SetActive(true);
            STTicks[0].gameObject.SetActive(true);
        }
        else if (currentStamina < 51 && currentStamina >= 41)
        {
            STTicks[11].gameObject.SetActive(false);
            STTicks[10].gameObject.SetActive(false);
            STTicks[9].gameObject.SetActive(false);
            STTicks[8].gameObject.SetActive(false);
            STTicks[7].gameObject.SetActive(false);
            STTicks[6].gameObject.SetActive(false);
            STTicks[5].gameObject.SetActive(false);
            STTicks[4].gameObject.SetActive(false);
            STTicks[3].gameObject.SetActive(true);
            STTicks[2].gameObject.SetActive(true);
            STTicks[1].gameObject.SetActive(true);
            STTicks[0].gameObject.SetActive(true);
        }
        else if (currentStamina < 41 && currentStamina >= 31)
        {
            STTicks[11].gameObject.SetActive(false);
            STTicks[10].gameObject.SetActive(false);
            STTicks[9].gameObject.SetActive(false);
            STTicks[8].gameObject.SetActive(false);
            STTicks[7].gameObject.SetActive(false);
            STTicks[6].gameObject.SetActive(false);
            STTicks[5].gameObject.SetActive(false);
            STTicks[4].gameObject.SetActive(false);
            STTicks[3].gameObject.SetActive(false);
            STTicks[2].gameObject.SetActive(true);
            STTicks[1].gameObject.SetActive(true);
            STTicks[0].gameObject.SetActive(true);
        }
        else if (currentStamina < 31 && currentStamina >= 21)
        {
            STTicks[11].gameObject.SetActive(false);
            STTicks[10].gameObject.SetActive(false);
            STTicks[9].gameObject.SetActive(false);
            STTicks[8].gameObject.SetActive(false);
            STTicks[7].gameObject.SetActive(false);
            STTicks[6].gameObject.SetActive(false);
            STTicks[5].gameObject.SetActive(false);
            STTicks[4].gameObject.SetActive(false);
            STTicks[3].gameObject.SetActive(false);
            STTicks[2].gameObject.SetActive(false);
            STTicks[1].gameObject.SetActive(true);
            STTicks[0].gameObject.SetActive(true);
        }
        else if (currentStamina < 21 && currentStamina >= 11)
        {
            STTicks[11].gameObject.SetActive(false);
            STTicks[10].gameObject.SetActive(false);
            STTicks[9].gameObject.SetActive(false);
            STTicks[8].gameObject.SetActive(false);
            STTicks[7].gameObject.SetActive(false);
            STTicks[6].gameObject.SetActive(false);
            STTicks[5].gameObject.SetActive(false);
            STTicks[4].gameObject.SetActive(false);
            STTicks[3].gameObject.SetActive(false);
            STTicks[2].gameObject.SetActive(false);
            STTicks[1].gameObject.SetActive(false);
            STTicks[0].gameObject.SetActive(true);
        }
        else if (currentStamina < 11 && currentStamina >= 1)
        {
            STTicks[11].gameObject.SetActive(false);
            STTicks[10].gameObject.SetActive(false);
            STTicks[9].gameObject.SetActive(false);
            STTicks[8].gameObject.SetActive(false);
            STTicks[7].gameObject.SetActive(false);
            STTicks[6].gameObject.SetActive(false);
            STTicks[5].gameObject.SetActive(false);
            STTicks[4].gameObject.SetActive(false);
            STTicks[3].gameObject.SetActive(false);
            STTicks[2].gameObject.SetActive(false);
            STTicks[1].gameObject.SetActive(false);
            STTicks[0].gameObject.SetActive(true);
        }
        else
        {
            STTicks[11].gameObject.SetActive(false);
            STTicks[10].gameObject.SetActive(false);
            STTicks[9].gameObject.SetActive(false);
            STTicks[8].gameObject.SetActive(false);
            STTicks[7].gameObject.SetActive(false);
            STTicks[6].gameObject.SetActive(false);
            STTicks[5].gameObject.SetActive(false);
            STTicks[4].gameObject.SetActive(false);
            STTicks[3].gameObject.SetActive(false);
            STTicks[2].gameObject.SetActive(false);
            STTicks[1].gameObject.SetActive(false);
            STTicks[0].gameObject.SetActive(false);
        }

        
        
    }
                

    public void UseStamina(float amount)
    {
        if(currentStamina - amount >= 0)
        {
            
            currentStamina -= amount;
            //staminaBar.value = currentStamina;

           

            if(regen != null)
            {
                StopCoroutine(regen);
            }

            regen = StartCoroutine(RegenStamina());
        }
        else if (currentStamina == 0)
        {
            Debug.Log("Not enough stamina!");
          
        }
    }

    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(2);

        while(currentStamina < maxStamina)
        {
            currentStamina += maxStamina / 120;
            //staminaBar.value = currentStamina;
            yield return regenTick;
        }



        if (currentStamina == 120)
        {
            currentStamina = 1;
        }
        else if(currentStamina < 120 && currentStamina >= 111)
        {

        }
    }


}
