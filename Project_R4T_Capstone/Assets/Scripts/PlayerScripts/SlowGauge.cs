using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlowGauge : MonoBehaviour
{ 

    public Slider slowBar;
    public int maxSlow = 100;
    public float currentSlow; // do not touch in inspector

    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine regen;

    public static SlowGauge instance;

    public gunShoot gun;

    public Image[] SlowGTicks;


    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentSlow = maxSlow;
        slowBar.maxValue = maxSlow;
        slowBar.value = maxSlow;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentSlow > 1)
        {
            if(Input.GetKey(KeyCode.Mouse1))
            {
                UseSlow(0.1f);
            }
            else if (currentSlow <= 1)
            {
                slowBar.value = currentSlow;
                gun.slowSpeed = 1f;
            }
        }

        if(currentSlow == 100)
        {
            SlowGTicks[7].gameObject.SetActive(true);
            SlowGTicks[6].gameObject.SetActive(true);
            SlowGTicks[5].gameObject.SetActive(true);
            SlowGTicks[4].gameObject.SetActive(true);
            SlowGTicks[3].gameObject.SetActive(true);
            SlowGTicks[2].gameObject.SetActive(true);
            SlowGTicks[1].gameObject.SetActive(true);
            SlowGTicks[0].gameObject.SetActive(true);
        }
        else if(currentSlow < 100 && currentSlow >= 87.5 )
        {
            SlowGTicks[7].gameObject.SetActive(true);
            SlowGTicks[6].gameObject.SetActive(true);
            SlowGTicks[5].gameObject.SetActive(true);
            SlowGTicks[4].gameObject.SetActive(true);
            SlowGTicks[3].gameObject.SetActive(true);
            SlowGTicks[2].gameObject.SetActive(true);
            SlowGTicks[1].gameObject.SetActive(true);
            SlowGTicks[0].gameObject.SetActive(false);
        }
        else if (currentSlow < 87.5 && currentSlow >= 75)
        {
            SlowGTicks[7].gameObject.SetActive(true);
            SlowGTicks[6].gameObject.SetActive(true);
            SlowGTicks[5].gameObject.SetActive(true);
            SlowGTicks[4].gameObject.SetActive(true);
            SlowGTicks[3].gameObject.SetActive(true);
            SlowGTicks[2].gameObject.SetActive(true);
            SlowGTicks[1].gameObject.SetActive(false);
            SlowGTicks[0].gameObject.SetActive(false);
        }
        else if (currentSlow < 75 && currentSlow >= 62.5)
        {
            SlowGTicks[7].gameObject.SetActive(true);
            SlowGTicks[6].gameObject.SetActive(true);
            SlowGTicks[5].gameObject.SetActive(true);
            SlowGTicks[4].gameObject.SetActive(true);
            SlowGTicks[3].gameObject.SetActive(true);
            SlowGTicks[2].gameObject.SetActive(false);
            SlowGTicks[1].gameObject.SetActive(false);
            SlowGTicks[0].gameObject.SetActive(false);
        }
        else if (currentSlow < 62.5 && currentSlow >= 50)
        {
            SlowGTicks[7].gameObject.SetActive(true);
            SlowGTicks[6].gameObject.SetActive(true);
            SlowGTicks[5].gameObject.SetActive(true);
            SlowGTicks[4].gameObject.SetActive(true);
            SlowGTicks[3].gameObject.SetActive(false);
            SlowGTicks[2].gameObject.SetActive(false);
            SlowGTicks[1].gameObject.SetActive(false);
            SlowGTicks[0].gameObject.SetActive(false);
        }
        else if (currentSlow < 50 && currentSlow >= 37.5)
        {
            SlowGTicks[7].gameObject.SetActive(true);
            SlowGTicks[6].gameObject.SetActive(true);
            SlowGTicks[5].gameObject.SetActive(true);
            SlowGTicks[4].gameObject.SetActive(false);
            SlowGTicks[3].gameObject.SetActive(false);
            SlowGTicks[2].gameObject.SetActive(false);
            SlowGTicks[1].gameObject.SetActive(false);
            SlowGTicks[0].gameObject.SetActive(false);
        }
        else if (currentSlow < 37.5 && currentSlow >= 25)
        {
            SlowGTicks[7].gameObject.SetActive(true);
            SlowGTicks[6].gameObject.SetActive(true);
            SlowGTicks[5].gameObject.SetActive(false);
            SlowGTicks[4].gameObject.SetActive(false);
            SlowGTicks[3].gameObject.SetActive(false);
            SlowGTicks[2].gameObject.SetActive(false);
            SlowGTicks[1].gameObject.SetActive(false);
            SlowGTicks[0].gameObject.SetActive(false);
        }
        else if (currentSlow < 25 && currentSlow >= 12.5)
        {
            SlowGTicks[7].gameObject.SetActive(true);
            SlowGTicks[6].gameObject.SetActive(false);
            SlowGTicks[5].gameObject.SetActive(false);
            SlowGTicks[4].gameObject.SetActive(false);
            SlowGTicks[3].gameObject.SetActive(false);
            SlowGTicks[2].gameObject.SetActive(false);
            SlowGTicks[1].gameObject.SetActive(false);
            SlowGTicks[0].gameObject.SetActive(false);
        }
        else if (currentSlow < 12.5 && currentSlow >= 0)
        {
            SlowGTicks[7].gameObject.SetActive(true);
            SlowGTicks[6].gameObject.SetActive(false);
            SlowGTicks[5].gameObject.SetActive(false);
            SlowGTicks[4].gameObject.SetActive(false);
            SlowGTicks[3].gameObject.SetActive(false);
            SlowGTicks[2].gameObject.SetActive(false);
            SlowGTicks[1].gameObject.SetActive(false);
            SlowGTicks[0].gameObject.SetActive(false);
        }
        else
        {
            SlowGTicks[7].gameObject.SetActive(false);
            SlowGTicks[6].gameObject.SetActive(false);
            SlowGTicks[5].gameObject.SetActive(false);
            SlowGTicks[4].gameObject.SetActive(false);
            SlowGTicks[3].gameObject.SetActive(false);
            SlowGTicks[2].gameObject.SetActive(false);
            SlowGTicks[1].gameObject.SetActive(false);
            SlowGTicks[0].gameObject.SetActive(false);
        }
    }

    public void UseSlow(float amount)
    {
        if(currentSlow -amount >= 0)
        {
            currentSlow -= amount;
            slowBar.value = currentSlow;

            if(regen != null)
            {
                StopCoroutine(regen);
            }

            regen = StartCoroutine(RegenSlow());




        }
    }
    private IEnumerator RegenSlow()
    {
        yield return new WaitForSeconds(2);

        while (currentSlow < maxSlow)
        {
            currentSlow += maxSlow / 100;
            slowBar.value = currentSlow;
            yield return regenTick;
        }
    }

}
