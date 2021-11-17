using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider staminaBar;

    private int maxStamina = 100;
    public float currentStamina;

    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine regen;

    public static StaminaBar instance;

    public GameObject thePlayer;
    private PlayerMovement thePlayerMovement;

    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {

        thePlayerMovement = thePlayer.GetComponent<PlayerMovement>();

        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;
    }

    private void Update()
    {
        if (currentStamina > 15)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                
                
                    UseStamina(0.20f);
                
                    
            }
            else if (currentStamina <= 15)
            {
                staminaBar.value = currentStamina;
            }
        }
    }

    public void UseStamina(float amount)
    {
        if(currentStamina - amount >= 0)
        {
            
            currentStamina -= amount;
            staminaBar.value = currentStamina;

           

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
            currentStamina += maxStamina / 100;
            staminaBar.value = currentStamina;
            yield return regenTick;
        }

        
    }
}
