using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlowGauge : MonoBehaviour
{ 

    public Slider slowBar;
    private int maxSlow = 100;
    public float currentSlow; // do not touch in inspector

    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine regen;

    public static SlowGauge instance;

    public gunShoot gun;


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
                UseSlow(0.40f);
            }
            else if (currentSlow <= 1)
            {
                slowBar.value = currentSlow;
                gun.slowSpeed = 1f;
            }
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
