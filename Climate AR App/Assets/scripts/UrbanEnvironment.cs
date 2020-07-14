using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrbanEnvironment : MonoBehaviour
{
    //public GameObject cityWater;
    public GameObject clouds;
    public GameObject rainStorm;
    public GameObject rainSound;

    //public float riverRaiseSpeed;
    //public float riverExpanseAmount;
    public float RainFallAmountOverTime; //how much rain is predicted per a time interval
    

    private bool stormHappening;
    private float expandSize = .01f;
    private float sizeLimit = 2.4f;
    private float totalRainFallAmount; //running total of the total rain fall, if there is no rain, then this amount slowly decreases...


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
            if (true) {
                Debug.Log("totalRainFallAmount " + totalRainFallAmount);
                totalRainFallAmount += RainFallAmountOverTime;
            }
        }
        else if (!stormHappening) // remove/shrink the clouds
        {
            if (clouds.transform.localScale.z > 0f)
            {
                clouds.transform.localScale = new Vector3(currentScale.x - expandSize, currentScale.y - expandSize, currentScale.z - expandSize);
            }
            if (totalRainFallAmount > 0.0f)
            {
                Debug.Log("totalRainFallAmount " + totalRainFallAmount);
                totalRainFallAmount -= RainFallAmountOverTime;
            }
        }
    }

    public void StartStorm(bool isRaising)
    {
        Debug.Log("start storm button clicked ");
        clouds.SetActive(true);
        stormHappening = true;
        rainStorm.SetActive(true);
        rainSound.GetComponent<EnviroAudioSource>().StartRainSound();
        rainSound.GetComponent<EnviroAudioSource>().playOnStart = true;
        //Vector3 currentPosition = cityWater.transform.position;
        //Vector3 currentScale = cityWater.transform.localScale;
        if (isRaising)
        {
          //  cityWater.transform.position = new Vector3(currentPosition.x, currentPosition.y+riverRaiseSpeed, currentPosition.z);
            //cityWater.transform.localScale = new Vector3(currentScale.x + riverExpanseAmount, currentScale.y, currentScale.z);

            //  transform.position = new Vector3(transform.position.x, 0, transform.position.z);

        }
    }

    public void EndStorm()
    {
        Debug.Log("end storm button clicked");
        rainSound.GetComponent<EnviroAudioSource>().FadeOut();
       rainStorm.SetActive(false);
        //rainSound.SetActive(false);
        stormHappening = false;

    }

    public float GetTotalRainFallAmount()
    {
        return totalRainFallAmount;
    }

    public bool GetIsStormHappening()
    {
        return stormHappening;
    }
}
