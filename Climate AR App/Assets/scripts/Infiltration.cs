using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*handles infiltration of the ground
 * //neeed to rename this script
 * in the future update, need to refactor this code and others to use anim events and not have things in the update function
 * helpful reference image https://www.google.com/imgres?imgurl=https%3A%2F%2Fengineering.purdue.edu%2Fmapserve%2FLTHIA7%2Fimages%2Frunoff_vs_infil_chart.gif&imgrefurl=https%3A%2F%2Fengineering.purdue.edu%2Fmapserve%2FLTHIA7%2Fdocumentation%2Frunoff.htm&tbnid=7iW4Nw1vZhw8YM&vet=12ahUKEwjvt6y7mdDqAhVDJX0KHSQzAy0QMygNegUIARCzAQ..i&docid=bLwZPOG3rZY4oM&w=399&h=201&q=soil%20infiltration%20and%20soil%20runoff%20graph&ved=2ahUKEwjvt6y7mdDqAhVDJX0KHSQzAy0QMygNegUIARCzAQ
 */
public class Infiltration : MonoBehaviour
{
    public GameObject RainInfo;
    public GameObject ground;
    public float speedOfRunoff;
    //public float RunOffStartPoint;//this number is figured out by manually seeing at what local Y point the water is viewable
    public float runOffIncrementAmount;
    //public float waterStorageDecrementAmount; //remove?

    public float infiltration; //how much the ground can soak up over a certain time. 
    public float decreaseAmount; //used for debugging
    public float delayTime; //used to simulate when the initial rainfall hits the ground and soaks up. a rich soil will have a low delay time. (initial infiltration )
    public float maxWaterLevel; //the limit of how high the water will go before flooding into the ocean etc
    public float waterSurfaceLevel; //the level at which the water starts to show
    float rain; // the rain falling
    private float startDelayAmount;
    private float startInifiltration;
    private float runoff;
    private float minLevelOfWater; //used to stop the water level from going "deep" below the ground.
    // Start is called before the first frame update
    void Start()
    {
        startInifiltration = infiltration;
        //theGround = ground.GetComponent<Ground>();
        //rain = RainInfo.GetComponent<UrbanEnvironment>().RainFallAmountOverTime; //get the amount of rain accumilating, this number increases when its raining and decreases till 0 when not raining
        startDelayAmount = delayTime;
        //groundStartingPoint = this.gameObject.transform.localPosition.y; //get the start of the water
        runoff = 0.0f;
        minLevelOfWater = this.transform.localPosition.y -.001f; // subtracted a small amount because for some reason the y value location is adjust slightly at run-time
    }

    // Update is called once per frame
    /*handles the water raising and lowering based off of rain. 
     * delay functionality is built to mimick the time it takes water to soak into the ground
     * once the delay is done, then the water storage stars to fill up.
     * once the storage is filled up, then the runoff occurs. 
     * the water will continue to raise until the max water level is met. the max water level is there for visual purposes and not scientific.
     */
    void Update()
    {
        if (RainInfo.GetComponent<UrbanEnvironment>().GetIsStormHappening() && (this.transform.localPosition.y < maxWaterLevel) ) //if it is raining and is below the max water level
        {
            //Debug.Log("delayAmount = " + delayAmount);
            if (delayTime > 0.0f)//old fashion timer
            {
                delayTime -= 1;
                AdjustWaterLevel(0f);
               // Debug.Log("qw delay amount this.gameObject.transform.localPosition .y = " + this.gameObject.transform.localPosition.y);
            }
            else // < the water is now infiltratiing the ground and the delay is done. We now will try to get the water into the ground. so subtract water lvl
            {
                //Debug.Log("runoff = " + runoff);
                if (!(runoff >= infiltration)) {//is the runoff less than infiltration
                    //AdjustWaterLevel(-.0001f); //make the water lvl go down since it is soaking up into the "earth". the math in the denominator is to slow down the decrease
                    AdjustWaterLevel(-2f*rain); //make the water lvl go down since it is soaking up into the "earth". the math in the denominator is to slow down the decrease
                }
                if (infiltration > 0f)
                {
                    infiltration -= decreaseAmount;

                }
                else
                {
                    infiltration = 0;
                }

                //Debug.Log("ww this.gameObject.transform.localPosition.y " + this.gameObject.transform.localPosition.y);

                    //Debug.Log("ww Runoff " + runoff);
                if (runoff <= (startInifiltration - 1f))
               {
                    runoff += decreaseAmount;
                }
                
            }

     
            if(runoff >= infiltration)
            {
                AdjustWaterLevel(speedOfRunoff);
            }

        }
        else if(!RainInfo.GetComponent<UrbanEnvironment>().GetIsStormHappening()) //not raining
        {
            if (infiltration <=startInifiltration)
            {
                infiltration += decreaseAmount + (decreaseAmount/2);
                AdjustWaterLevel(-3f * rain); //make the water lvl go down since it is soaking up into the "earth". the math in the denominator is to slow down the decrease
                //Debug.Log("qwe infiltration is " + infiltration + " startInifiltration " + startInifiltration);
            }
            else
            {
                ResetWaterLevel();
            }
            if (runoff > 0f)
            {
                runoff -= decreaseAmount;

            }
            else
            {
                runoff = 0.0f;
            }

        }

    }

    /*AdjustWaterLevel
     * adjust where the water is in the level
     * subratctAmount is used to simulate the water going into storage. 
     */
    void AdjustWaterLevel(float amount)
    {
        Debug.Log("ADJUST WATER minLevelOfWater " + minLevelOfWater);
        if (this.gameObject.transform.localPosition.y >= minLevelOfWater) {
            Vector3 newPos = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y + (rain + amount), this.transform.localPosition.z);
            gameObject.transform.localPosition = newPos;

        }

    }

    /**
     * reset the water level
     * this should be an anim, not by position... need to change in future update
     */
    void ResetWaterLevel()
    {
        Vector3 newPos = new Vector3(this.transform.localPosition.x, minLevelOfWater, this.transform.localPosition.z);
        gameObject.transform.localPosition = newPos;
    }

    /**
     * get the infiltration amount
     */
    public float GetInfiltration()
    {
        return infiltration;
    }


    /**
     * get the run off amount
     */
    public float GetRunoff()
    {
        return runoff;
    }

}
