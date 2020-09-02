﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrbanEnvironment : MonoBehaviour
{
    //public GameObject cityWater;
    public GameObject clouds;
    public GameObject rainStorm;
    public GameObject rainSound;
    public GameObject graphInfo;
    public List<GameObject> animations;

    //public float riverRaiseSpeed;
    //public float riverExpanseAmount;
    //public float RainFallAmountOverTime; //how much rain is predicted per a time interval

    private bool toggleWaterAnim = true;
    private bool stormHappening;
    private float expandSize = .01f;
    private float sizeLimit = 2.4f;
   // private float totalRainFallAmount; //running total of the total rain fall, if there is no rain, then this amount slowly decreases...


    // Start is called before the first frame update
    void Start()
    {
        
        clouds.SetActive(false);
        rainStorm.SetActive(false);
        //rainSound.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentScale = clouds.transform.localScale;
        if (stormHappening  ) // add/grow the clouds
        {
            if (clouds.transform.localScale.z < sizeLimit) {
                clouds.transform.localScale = new Vector3(currentScale.x + expandSize, currentScale.y + expandSize, currentScale.z + expandSize);
    
            }
            if (toggleWaterAnim) //the clouds are growing so start the water animation
            {
                toggleWaterAnim = false;
                for(int i = 0; i < animations.Count; i++)
                {
                    animations[i].GetComponent<Animator>().SetBool("StartRiverIncrease", true); //start the animation, the string value is a parameter from the animator window
                }
            }
            if (graphInfo.GetComponent<HydroGraphDataRain>().getRainIsDecreasing())
            {
                EndStorm();

            }

        }
        else if (!stormHappening) // remove/shrink the clouds
        {
            if (clouds.transform.localScale.z > 0f)
            {
                clouds.transform.localScale = new Vector3(currentScale.x - expandSize, currentScale.y - expandSize, currentScale.z - expandSize);
            }
            if(!toggleWaterAnim && graphInfo.GetComponent<HydroGraphLands>().getCityLandIsPeaked())
            {
                for (int i = 0; i < animations.Count; i++)
                {
                    animations[i].GetComponent<Animator>().SetBool("StartRiverIncrease", false); //start the animation, the string value is a parameter from the animator window
                }
                toggleWaterAnim = true;
            }

        }
    }

    /**
     * called by UI button
     */
    public void StartStorm()
    {
        //start the graph
        graphInfo.GetComponent<HydroGraphDataRain>().setStartGraph(true);
        graphInfo.GetComponent<HydroGraphLands>().setStartGraph(true);

        Debug.Log("start storm button clicked ");
        clouds.SetActive(true);
        stormHappening = true;
        rainStorm.SetActive(true);
        rainSound.GetComponent<EnviroAudioSource>().StartRainSound();
        rainSound.GetComponent<EnviroAudioSource>().playOnStart = true;
     

    }

    /**
    * called by UI button
    * going to not have the end storm button for now. want to focus on an MVP!
    */
    public void EndStorm()
    {
        Debug.Log("end storm button clicked");
        rainSound.GetComponent<EnviroAudioSource>().FadeOut();
       rainStorm.SetActive(false);
        //rainSound.SetActive(false);
        stormHappening = false;

    }

   // public float GetTotalRainFallAmount()
    //{
   //     return totalRainFallAmount;
    //}

    public bool GetIsStormHappening()
    {
        return stormHappening;
    }
}
