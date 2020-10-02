using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class agricultureStorm : MonoBehaviour
{
    public GameObject stormClouds;
    public GameObject rain;
    public GameObject rainSound;
    public GameObject TextFrame;
    public GameObject landGM;

    // Start is called before the first frame update
    void Start()
    {
        stormClouds.SetActive(false);
        rain.SetActive(false);
        rainSound.SetActive(false);
        TextFrame.SetActive(false);
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

    void StartRain()
    {
        rain.SetActive(true);
        rainSound.SetActive(true);
        landGM.GetComponent<landGM>().StartErosions();
    }

    void EndRain()
    {
        rain.SetActive(false);
        rainSound.GetComponent<EnviroAudioSource>().FadeOut();
    }
}
