using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingEffects : MonoBehaviour
{
    [SerializeField] public SlowGauge timeDrain; //this variable is to connect the the gauge and allow the leech to drain
    private PostProcessVolume _postProcessVolume; //call the Post-process Volume that has effects
    private ChromaticAberration _cA;
    private Bloom _bL;
    private Grain _gR;

    

    // Start is called before the first frame update
    void Start()
    {

        timeDrain = GameObject.Find("Canvas").transform.GetChild(0).GetComponent<SlowGauge>();
        _postProcessVolume = GameObject.Find("Canvas").GetComponent<PostProcessVolume>();
       

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
            
        }
        if (Input.GetKeyUp(KeyCode.Mouse1) || timeDrain.currentSlow <= 1)
        {
            
           // _cA.SetAllOverridesTo(false);
        }


    } 

    public void Bloom()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && timeDrain.currentSlow > 1)
        {
            _bL.active = true ;

        }
        if (Input.GetKeyUp(KeyCode.Mouse1) || timeDrain.currentSlow <= 1)
        {

           // _bL.SetAllOverridesTo(false);
        }
    }

    public void Grain()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && timeDrain.currentSlow > 1)
        {
            _gR.active = true;

        }
        if (Input.GetKeyUp(KeyCode.Mouse1) || timeDrain.currentSlow <= 1)
        {

          //  _gR.SetAllOverridesTo(false);
        }
    }


}
