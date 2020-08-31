using ChartAndGraph;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class HydroGraphDataRain : MonoBehaviour
{
    public GraphChart Graph;
    public float waterLimit = 3f;
    public float waterAddAmount = .5f;
    public int waterPeakFlatlineTime = 10;
    float lastTime = 0f; 
    float waterLevelXValue = 0f;
    float waterLevelYValue = 0f;
    bool rainIsPeaked = false;
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
        if (lastTime + 1f < time)
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

    public bool GetRainPeakedBool()
    {
        return rainIsPeaked;
    }

    public float GetWaterLevelXValue()
    {
        return waterLevelXValue;
    }

    public float GetWaterLevelYValue()
    {
        return waterLevelYValue;
    }
}
