using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * handles the clouds coming into the farm scene. 
 * activates the rain object
 * hanldes the pond waters
 * many of the functions are called by the animator
 */
public class agricultureStorm : MonoBehaviour
{
    public GameObject stormClouds;
    public GameObject rain;
    public GameObject rainSound;
    public GameObject TextFrame;
    public GameObject badLandGM;
    public GameObject goodLandGM;
    public GameObject hidePOIArrow;
    public GameObject pondWaterSloped; //only for the sloped good managed side
    public GameObject pondWaterSteepSloped; //only for the steep sloped good managed side
    public GameObject hideCanvas; //keep in mind that infoPOPUp references this canvas too
    public GameObject popUpGM;


    private bool pondRaiseFlag; //ensures water anim is called only once
    private bool pondRaiseFlagSteep; //ensures water anim is called only once
    private bool showStartButtonOnce;

    // Start is called before the first frame update
    void Start()
    {
        stormClouds.SetActive(false);
        rain.SetActive(false);
        rainSound.SetActive(false);
        TextFrame.SetActive(false);
        pondRaiseFlag = true;
        pondRaiseFlagSteep = true;
        pondWaterSloped.SetActive(false);
        pondWaterSteepSloped.SetActive(false);
        showStartButtonOnce = true;
    }

    /**
     * show the inform canvas text. called by button
     */
    public void ShowText()
    {
        TextFrame.SetActive(true);

    }

    /**
     * start the storm and sounds.
     * called by button
     */
    public void StartStorm()
    {
        Debug.Log("start the storm ");
        TextFrame.SetActive(false);
        stormClouds.SetActive(true);
        stormClouds.GetComponent<Animator>().SetBool("StartStorm", true); //start the animation
       // rain.SetActive(true);

    }

    /**
    * end the storm and sounds.
    * called by erosion of soil cube
    */
    public void EndStorm()
    {
        stormClouds.GetComponent<Animator>().SetBool("StartStorm", false); //start the animation
        popUpGM.GetComponent<PopUpHandler>().DoneWithSpecialEvent();
    }

    void HideClouds()
    {
        stormClouds.SetActive(false);
    }

    /**
     * called by animation when the rain starts in the comming storm anim
     * starts the erosions
     */
    void StartRain()
    {
        rain.SetActive(true);
        rainSound.SetActive(true);
        badLandGM.GetComponent<landGM>().StartErosions();
        goodLandGM.GetComponent<landGM>().StartErosions();
        rainSound.GetComponent<EnviroAudioSource>().StartRainSound();
        rainSound.GetComponent<EnviroAudioSource>().playOnStart = true;
    }

    void EndRain()
    {
        rain.SetActive(false);
        rainSound.GetComponent<EnviroAudioSource>().FadeOut();
    }

    /**
     * hides the POI arrow and the storm button canvas so the user can enjoy the storm
     * will only show if showStartButtonOnce is true
     */
    public void HidePOIArrowAndCanvas()
    {
        if (showStartButtonOnce)
        {
            hidePOIArrow.SetActive(false);
            hideCanvas.SetActive(false);
            showStartButtonOnce = false;
        }
    }

    /**
  * show the POI arrow and the storm button canvas so the user can start the storm
  * called by button
  */
    public void ShowPOIArrowAndCanvas()
    {
      
            hidePOIArrow.SetActive(true);
            hideCanvas.SetActive(true);
        
    }

    /**
     * called by animation
     */
    public void StartSlopePond()
    {
        if (pondRaiseFlag)
        {
            pondWaterSloped.SetActive(true);
            pondWaterSloped.GetComponent<Animator>().SetBool("startRaise", true);
            pondRaiseFlag = false;
        }
    }

    /**
      * called by animation
      */
    public void StartSteepSlopePond()
    {
        if (pondRaiseFlagSteep)
        {
            pondWaterSteepSloped.SetActive(true);
            pondWaterSteepSloped.GetComponent<Animator>().SetBool("startRaise", true);
            pondRaiseFlagSteep = false;
        }
    }

    /**
     * called by the anim that is having the storm looping
     */
    public void CheckIfSoilDoneWithErosions()
    {
        if (badLandGM.GetComponent<landGM>().CheckIfSoilGMErosionDone() && goodLandGM.GetComponent<landGM>().CheckIfSoilGMErosionDone())
        {
            EndStorm();

        }
    }

    /**
     * restart the storm for the user to reselect their options
     */
    public void RestartStormCanvasAndPOI()
    {
        //StartStorm();
        showStartButtonOnce = true;
        HidePOIArrowAndCanvas();
    }
}
