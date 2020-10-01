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

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowText()
    {
        TextFrame.SetActive(true);

    }

    public void StartStorm()
    {
        Debug.Log("start the storm ");
        TextFrame.SetActive(false);
        stormClouds.SetActive(true);
        rain.SetActive(true);
        rainSound.SetActive(true);
        rainSound.GetComponent<EnviroAudioSource>().StartRainSound();
        rainSound.GetComponent<EnviroAudioSource>().playOnStart = true;
        landGM.GetComponent<landGM>().StartErosions();
    }

    public void EndStorm()
    {

    }
}
