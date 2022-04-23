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
        timeDrain = GameObject.Find("Canvas").transform.GetChild(0).GetComponent<SlowGauge>();
        _postProcessVolume = GameObject.Find("PostProcessProfile").GetComponent<PostProcessVolume>();
        _postProcessVolume.profile.TryGetSettings(out _cA);
        _postProcessVolume.profile.TryGetSettings(out _bL);
        _postProcessVolume.profile.TryGetSettings(out _gR);
    }

    private void Update()
    {
        ChromaticAberration();
        Bloom();
        Grain();
    }

    public void ChromaticAberration()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && timeDrain.currentSlow > 1)
        {
            _cA.active = true;
            _cA.SetAllOverridesTo(true);
        }
        if (Input.GetKeyUp(KeyCode.Mouse1) || timeDrain.currentSlow <= 1)
        {

            _cA.SetAllOverridesTo(false);
        }


    }

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
