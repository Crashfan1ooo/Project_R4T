using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostPEffects : MonoBehaviour
{
    [SerializeField] public SlowGauge timeDrain; //this variable is to connect the the gauge and allow the leech to drain
    private PostProcessVolume _postProcessVolume; //call the Post-process Volume that has effects
    public ChromaticAberration _cA;
    private Bloom _bL;
    private Grain _gR;



    // Start is called before the first frame update
    void Start()
    {
        //important stuff

        //talks to the slow gauge
        timeDrain = GameObject.Find("Canvas").transform.GetChild(2).GetComponent<SlowGauge>();
        //gets the postprocessprofile
        _postProcessVolume = GameObject.Find("PostProcessProfile").GetComponent<PostProcessVolume>();

        //talk to all the settings currently in use
        _postProcessVolume.profile.TryGetSettings(out _cA);
        _postProcessVolume.profile.TryGetSettings(out _bL);
        _postProcessVolume.profile.TryGetSettings(out _gR);
    }

    private void Update()
    {
        //current effects in play
        ChromaticAberration();
        Bloom();
        Grain();
    }

    public void ChromaticAberration()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && timeDrain.currentSlow > 1)
        {
            _cA.active = true;
            //sets all the overides to on
            //show effects
            _cA.SetAllOverridesTo(true);
        }
        if (Input.GetKeyUp(KeyCode.Mouse1) || timeDrain.currentSlow <= 1)
        {

            //turns the overides off
            //no effects
            _cA.SetAllOverridesTo(false);
        }


    }

    //code repeats down below

    public void Bloom()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && timeDrain.currentSlow > 1)
        {
            _bL.active = true;
            _bL.SetAllOverridesTo(true);

        }
        if (Input.GetKeyUp(KeyCode.Mouse1) || timeDrain.currentSlow <= 1)
        {

             _bL.SetAllOverridesTo(false);
        }
    }

    public void Grain()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && timeDrain.currentSlow > 1)
        {
            _gR.active = true;
            _gR.SetAllOverridesTo(true);

        }
        if (Input.GetKeyUp(KeyCode.Mouse1) || timeDrain.currentSlow <= 1)
        {

              _gR.SetAllOverridesTo(false);
        }
    }



}
