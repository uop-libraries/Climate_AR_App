using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChartAndGraph;
using System;

public class HydroGraphLands : MonoBehaviour
{
    public GraphChart Graph;
    float cityXValue = 0f;
    float cityYValue = 0f;
    float lastTime = 0f;
    float cityLandIncrease = .01f;
    bool landIsPeaked = false;
    float maxCityLandLimit =4f;
    int cityLineFlatlineTime = 5;
    float tempCityLevelYValue = 0f;
    // Start is called before the first frame update
    void Start()
    {
        if (Graph == null) // the ChartGraph info is obtained via the inspector
            return;
        Graph.DataSource.ClearCategory("Player 2"); // clear the "Player 1" category. this category is defined using the GraphChart inspector
        Graph.DataSource.AddPointToCategoryRealtime("Player 2", cityXValue, cityYValue, 1f); // each time we call AddPointToCategory 

    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<HydroGraphDataRain>().GetRainPeakedBool()) //rain is peaked
        //if (true) //rain is peaked
        {
            float time = Time.time;
            if (lastTime + 1f < time)
            {
                cityXValue += cityLandIncrease;
                Debug.Log("cityYValue is " + cityYValue);
                if (!landIsPeaked) //increase graph
                {
                    Debug.Log("increase the graph");
                    tempCityLevelYValue += cityLandIncrease;
                    if (tempCityLevelYValue <= maxCityLandLimit && tempCityLevelYValue > 0f)
                    {
                        Debug.Log("set cityYvalue the graph");
                        cityYValue = tempCityLevelYValue;
                        Debug.Log("cityYValue is " + cityYValue);
                        Graph.DataSource.AddPointToCategoryRealtime("Player 2", cityXValue, cityYValue, 1f); // each time we call AddPointToCategory
                    }
                    else if(Math.Abs(cityYValue - maxCityLandLimit) <= .2f)
                    {
                        tempCityLevelYValue = maxCityLandLimit;
                        landIsPeaked = true;
                    }
                }
                else if (landIsPeaked && cityLineFlatlineTime >= 0) //flatline
                {
                    Debug.Log("flatline is reached");
                    cityLineFlatlineTime--;
                    Graph.DataSource.AddPointToCategoryRealtime("Player 2", cityXValue, cityYValue, 1f); // each time we call AddPointToCategory 
                }
                else if (cityYValue - cityLandIncrease >= 0f) //decrease graph
                {
                    Debug.Log("decrease cityYValue - cityLandIncrease >= 0f tempCityLevelYValue = " + tempCityLevelYValue);
                    tempCityLevelYValue -= cityLandIncrease;
                    if (tempCityLevelYValue >= 0f)
                    {
                        Debug.Log("decrease");
                        cityYValue = tempCityLevelYValue;
                        Graph.DataSource.AddPointToCategoryRealtime("Player 2", cityXValue, cityYValue, 1f); // each time we call AddPointToCategory 
                    }

                }
            }
            //start increase when rainPeaked is true
            //increase the land line sharply until max is reached. 
            //flatline a bit, then drop
        }
    }
}
