using ChartAndGraph;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


/**
 * handles the rain information and water amount to the land
 */
public class HydroGraphDataRain : MonoBehaviour
{
    public GraphChart Graph;
    public float waterLimit = 3f;
    [Tooltip("increase to speed up the graph")]
    public float waterAddAmount = .5f;
    public int waterPeakFlatlineTime = 10;
    float lastTime = 0f; 
    float waterLevelXValue = 0f;
    float waterLevelYValue = 0f;
    bool rainIsPeaked = false;
    bool rainIsDecreasing = false;
    bool startGraph = false;
    // Start is called before the first frame update
    void Start()
    {
        if (Graph == null) // the ChartGraph info is obtained via the inspector
            return;
        Graph.DataSource.ClearCategory("Rain"); // clear the "Player 1" category. this category is defined using the GraphChart inspector
                                                    //Graph.DataSource.ClearCategory("Player 2"); // clear the "Player 2" category. this category is defined using the GraphChart inspector
        Graph.DataSource.AddPointToCategoryRealtime("Rain", waterLevelXValue, waterLevelYValue, 1f); // each time we call AddPointToCategory 

    }

    // Update is called once per frame
    /*
     * Handles the increase, flatlining and decreasing graph for the rain.
     */
    void Update()
    {
        float time = Time.time;
        Debug.Log("waterLevelYValue is " + waterLevelYValue);
        if (lastTime + 1f < time && startGraph)
        {
            lastTime = time;
            waterLevelXValue += waterAddAmount;

            if (!rainIsPeaked) //increase graph
            {
                float tempWaterLevelYValue = Random.Range(waterLevelYValue, (waterLevelYValue + waterAddAmount)); //want some variation to the graph
                if (tempWaterLevelYValue <= waterLimit && tempWaterLevelYValue > 0f) 
                {
                    waterLevelYValue = tempWaterLevelYValue;
                    Graph.DataSource.AddPointToCategoryRealtime("Rain", waterLevelXValue, waterLevelYValue, 1f); // each time we call AddPointToCategory
                }
                if (Math.Abs(waterLevelYValue - waterLimit) <= .5f) //once the limit is reached, start the flatlining
                {
                    rainIsPeaked = true;
                }

            }
            else if (rainIsPeaked && waterPeakFlatlineTime >=0) //flatline
            {
                waterPeakFlatlineTime--;
                Graph.DataSource.AddPointToCategoryRealtime("Rain", waterLevelXValue, waterLevelYValue, 1f); // add points to the graph
            }
            else if (waterLevelYValue - waterAddAmount >= 0f) //decrease graph
            {
                rainIsDecreasing = true;
                Debug.Log("waterlevel is bigger thans 0");
                float tempWaterLevelYValue = Random.Range(waterLevelYValue - waterAddAmount, waterLevelYValue); //want some variation to the graph
                if (tempWaterLevelYValue > 0f)
                {
                    waterLevelYValue = tempWaterLevelYValue;
                    Graph.DataSource.AddPointToCategoryRealtime("Rain", waterLevelXValue, waterLevelYValue, 1f); // each time we call AddPointToCategory 
                }
          
            }
        }
    }

    /**
     * get the bool to check of the rain is peaked
     */
    public bool GetRainPeakedBool()
    {
        return rainIsPeaked;
    }

    /**
     * get the water level X value
     */
    public float GetWaterLevelXValue()
    {
        return waterLevelXValue;
    }

    /**
  * get the water level Y value
  */
    public float GetWaterLevelYValue()
    {
        return waterLevelYValue;
    }

    /**
     * get the bool to check if the rain is decreasing or going away
     */
    public bool getRainIsDecreasing()
    {
        return rainIsDecreasing;
    }

    /**
    * set the start graphs by passed in parameter
    */
    public void setStartGraph(bool value)
    {
        startGraph = value;
    }
}
