using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*handles infiltration of the ground
 * 
 */
public class Infiltration : MonoBehaviour
{
    public GameObject RainInfo;
    public GameObject ground;
    public float speedOfRunoff;
    
    float rainFallAmount;
    float rain; // the rain falling
    private float delayAmount;
    private float startDelayAmount;
    private float currentWaterStorageAmount;
    private Ground theGround;

    // Start is called before the first frame update
    void Start()
    {
        theGround = ground.GetComponent<Ground>();
        //grounds = GetGrounds(); //get all of the grounds in the scene
        rain = RainInfo.GetComponent<UrbanEnvironment>().RainFallAmountOverTime; //get the amount of rain accumilating, this number increases when its raining and decreases till 0 when not raining
        delayAmount = theGround.delayWaterInfiltration;
        startDelayAmount = delayAmount;
        currentWaterStorageAmount = 0; // no water in the storage at start
        
    }

    // Update is called once per frame
    void Update()
    {
        //rainFallAmount = RainInfo.GetComponent<UrbanEnvironment>().GetTotalRainFallAmount(); //get the amount of rain accumilating, this number increases when its raining and decreases till 0 when not raining
        //if raining
        //then start adding the water level above the ground level 
        // if until a certain point (the adjusted delay)
        // then water level starts to go down based off of infiltration rate. water level = rain - infiltration rate
        // if water storage is met then set infiltration to 0 (cant soak up anymore! )

        if (RainInfo.GetComponent<UrbanEnvironment>().GetIsStormHappening() && (this.transform.localPosition.y < theGround.maxWaterLevel) )
        {
            //Debug.Log("delayAmount = " + delayAmount);
            if (delayAmount > 0.0f)//old fashion timer
            {
                delayAmount -= 1;
                AdjustWaterLevel(0f);
                Debug.Log("qw delay amount this.gameObject.transform.localPosition .y = " + this.gameObject.transform.localPosition.y);
            }
            else if(!Mathf.Approximately(currentWaterStorageAmount , theGround.waterStorageAmount ) )// < the water is now infiltratiing the ground and the delay is done. We now will try to get the water into the ground. so subtract water lvl
            {
                //the water will continue to subtract until water storage is met
                AdjustWaterLevel(theGround.infiltrationAmountOverTime);

                currentWaterStorageAmount += .1f;
                Debug.Log("qw currentWaterStorageAmount this.gameObject.transform.localPosition .y = " + this.gameObject.transform.localPosition.y);
            }
            else
            {
                AdjustWaterLevel(0);
                rain += speedOfRunoff;
                Debug.Log("qw else this.transform.localPosition .y = " + this.gameObject.transform.localPosition.y);

            }

        }
        else //not raining
        {
            //delayAmount = startDelayAmount;
        }

    }

    void AdjustWaterLevel(float subtractAmount)
    {
        Vector3 newPos = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y + (rain - subtractAmount), this.transform.localPosition.z);
        gameObject.transform.localPosition = newPos;
    }

    void CalculateWaterInfiltration()
    {
        // GetTotalRainFallAmount
    }


}
