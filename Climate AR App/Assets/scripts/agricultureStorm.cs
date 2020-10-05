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
        rainSound.GetComponent<EnviroAudioSource>().StartRainSound();
        rainSound.GetComponent<EnviroAudioSource>().playOnStart = true;
    }

    /**
    * end the storm and sounds.
    * called by button
    */
    public void EndStorm()
    {
        stormClouds.GetComponent<Animator>().SetBool("StartStorm", false); //start the animation
    }

    void HideClouds()
    {
        stormClouds.SetActive(false);
    }

    /**
     * called by animation when the rain starts in the comming storm anim
     */
    void StartRain()
    {
        rain.SetActive(true);
        rainSound.SetActive(true);
        badLandGM.GetComponent<landGM>().StartErosions();
        goodLandGM.GetComponent<landGM>().StartErosions();
    }

    void EndRain()
    {
        rain.SetActive(false);
        rainSound.GetComponent<EnviroAudioSource>().FadeOut();
    }

    /**
     * hides the POI arrow and the storm button canvas so the user can enjoy the storm
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
}
