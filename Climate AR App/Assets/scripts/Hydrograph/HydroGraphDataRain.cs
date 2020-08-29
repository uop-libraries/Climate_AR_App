using ChartAndGraph;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class HydroGraphDataRain : MonoBehaviour
{
    public GraphChart Graph;
    float lastTime = 0f;
    float lastX = 0f;
    float waterLimit = 3f;
    float waterLevelXValue = 0f;
    float waterAddAmount =.5f;
    float waterLevelYValue = 0f;
    bool rainIsPeaked = false;
    int waterPeakFlatlineTime = 10;
    // Start is called before the first frame update
    void Start()
    {
        if (Graph == null) // the ChartGraph info is obtained via the inspector
            return;
        /////   Graph.DataSource.StartBatch(); // do not call StartBatch for realtime calls , it will only slow down performance.

        Graph.DataSource.ClearCategory("Player 1"); // clear the "Player 1" category. this category is defined using the GraphChart inspector
                                                    //Graph.DataSource.ClearCategory("Player 2"); // clear the "Player 2" category. this category is defined using the GraphChart inspector
        Graph.DataSource.AddPointToCategoryRealtime("Player 1", waterLevelXValue, waterLevelYValue, 1f); // each time we call AddPointToCategory 

    }

    // Update is called once per frame
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
                float tempWaterLevelYValue = Random.Range(waterLevelYValue, (waterLevelYValue + waterAddAmount));
                if (tempWaterLevelYValue <= waterLimit && tempWaterLevelYValue > 0f)
                {
                    waterLevelYValue = tempWaterLevelYValue;
                    Graph.DataSource.AddPointToCategoryRealtime("Player 1", waterLevelXValue, waterLevelYValue, 1f); // each time we call AddPointToCategory
                }
                if (Math.Abs(waterLevelYValue - waterLimit) <= .5f)
                {
                    rainIsPeaked = true;
                }

            }
            else if (rainIsPeaked && waterPeakFlatlineTime >=0) //flatline
            {
                waterPeakFlatlineTime--;
                Graph.DataSource.AddPointToCategoryRealtime("Player 1", waterLevelXValue, waterLevelYValue, 1f); // each time we call AddPointToCategory 
            }
            else if (waterLevelYValue - waterAddAmount >= 0f) //decrease graph
            {
                Debug.Log("waterlevel is bigger thans 0");
                float tempWaterLevelYValue = Random.Range(waterLevelYValue - waterAddAmount, waterLevelYValue);
                if (tempWaterLevelYValue > 0f)
                {
                    waterLevelYValue = tempWaterLevelYValue;
                    Graph.DataSource.AddPointToCategoryRealtime("Player 1", waterLevelXValue, waterLevelYValue, 1f); // each time we call AddPointToCategory 
                }
          
            }
        }
    }

    public bool GetRainPeakedBool()
    {
        return rainIsPeaked;
    }
}
