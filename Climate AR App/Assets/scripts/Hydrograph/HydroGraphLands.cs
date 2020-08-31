using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChartAndGraph;
using System;
using Random = UnityEngine.Random;
public class HydroGraphLands : MonoBehaviour
{
    public GraphChart Graph;
    float lastTime = 0f;
    public int parkLandDelayTimerLimit;
    int parkTimer;
    //------*city vars*------
    public int cityLineFlatlineTime = 50;
    public float cityLandIncrease = .01f;
    public float maxCityLandLimit = 4f;
    float cityXValue = .1f;
    float cityYValue = .1f;
    bool cityIsPeaked = false;
    float tempCityLevelYValue = .5f;

    //------*park vars*------
    public int parkLineFlatlineTime = 2;
    public float parkLandIncrease = .001f;
    public float maxParkLandLimit = 3f;
    public float flattenCurveLineForPark = 0f; 
    float parkXValue = .1f;
    float parkYValue = .1f;
    bool parkIsPeaked = false;
    float tempParkLevelYValue = .5f;
    // Start is called before the first frame update
    //float oldParkYValue = 0f;
    bool startParkGraph = false;
    void Start()
    {
        if (Graph == null) // the ChartGraph info is obtained via the inspector
            return;
        Graph.DataSource.ClearCategory("City Land"); // clear the "Player 1" category. this category is defined using the GraphChart inspector
        Graph.DataSource.ClearCategory("Park Land"); // clear the "Player 1" category. this category is defined using the GraphChart inspector
        Graph.DataSource.AddPointToCategoryRealtime("City Land", cityXValue, cityYValue, 1f); // each time we call AddPointToCategory 
        Graph.DataSource.AddPointToCategoryRealtime("Park Land", cityXValue, cityYValue, 1f); // each time we call AddPointToCategory 

    }

    // Update is called once per frame
    /*handles the increase, flatline and decreasing of the hyrograph for lands. 
     * 
     */
    void Update()
    {          
        cityXValue = this.GetComponent<HydroGraphDataRain>().GetWaterLevelXValue();
        parkXValue = this.GetComponent<HydroGraphDataRain>().GetWaterLevelXValue();
        if (this.GetComponent<HydroGraphDataRain>().GetRainPeakedBool()) //rain is peaked, start the increase of the river flow increase
        {
            cityLand(cityXValue);
            parkLand(parkXValue);
        }
        else //the start flatlining of the river flow
        {

            Graph.DataSource.AddPointToCategoryRealtime("City Land", cityXValue, cityYValue, 1f); // each time we call AddPointToCategory
            Graph.DataSource.AddPointToCategoryRealtime("Park Land", parkXValue, parkYValue, 1f); // each time we call AddPointToCategory
        }

        if (parkTimer  >= parkLandDelayTimerLimit)
        {
            startParkGraph = true;
        }

    }

    void cityLand(float xValue)
    {
 
            float time = Time.time;
            if (lastTime + 1f < time)
            {
            //cityXValue += cityLandIncrease;
            parkXValue = xValue;
            if (!cityIsPeaked) //increase graph
                {
                    tempCityLevelYValue = Random.Range(cityYValue, (cityYValue + cityLandIncrease)); //want some variation to the graph
                    //tempCityLevelYValue += cityLandIncrease;
                    if (tempCityLevelYValue <= maxCityLandLimit && tempCityLevelYValue > 0f)
                    {
                        cityYValue = tempCityLevelYValue;
                        Graph.DataSource.AddPointToCategoryRealtime("City Land", cityXValue, cityYValue, 1f); // each time we call AddPointToCategory
                }
                else if (Math.Abs(cityYValue - maxCityLandLimit) <= .2f)
                    {
                        tempCityLevelYValue = maxCityLandLimit;
                        cityIsPeaked = true;
                    }
                }
                else if (cityIsPeaked && cityLineFlatlineTime >= 0) //flatline
                {
                    cityLineFlatlineTime--;
                    Graph.DataSource.AddPointToCategoryRealtime("City Land", cityXValue, cityYValue, 1f); // each time we call AddPointToCategory 
                }
                else if (cityYValue - cityLandIncrease >= 0f) //decrease graph
                {
                tempCityLevelYValue = Random.Range(cityYValue - cityLandIncrease, cityYValue); //want some variation to the graph
                //tempCityLevelYValue -= cityLandIncrease;
                    if (tempCityLevelYValue >= 0f)
                    {
                        cityYValue = tempCityLevelYValue;
                        Graph.DataSource.AddPointToCategoryRealtime("City Land", cityXValue, cityYValue, 1f); // each time we call AddPointToCategory 
                    }

                }
            parkTimer++;
        }


    }

    void parkLand(float xValue)  
    {
            float time = Time.time;
            if (lastTime + 1f < time && startParkGraph)
            {
            //parkXValue += parkLandIncrease;
            parkXValue = xValue;
                if (!parkIsPeaked) //increase graph
                {
                //tempParkLevelYValue += parkLandIncrease;
                tempParkLevelYValue = (Random.Range(parkYValue, (parkYValue + parkLandIncrease))) - flattenCurveLineForPark; //want some variation to the graph, need to flatten the curve since its park land
                    if (tempParkLevelYValue <= maxParkLandLimit && tempParkLevelYValue > 0f && tempParkLevelYValue >= parkYValue)
                    {
                        parkYValue = tempParkLevelYValue;
                        Graph.DataSource.AddPointToCategoryRealtime("Park Land", parkXValue, parkYValue, 1f); // each time we call AddPointToCategory
                    }
                    else if (Math.Abs(parkYValue - maxParkLandLimit) <= .2f)
                    {
                        tempParkLevelYValue = maxParkLandLimit;
                        parkIsPeaked = true;
                    }
                    else
                    {
                        Graph.DataSource.AddPointToCategoryRealtime("Park Land", parkXValue, parkYValue, 1f); // each time we call AddPointToCategory 

                    }
                }
                else if (parkIsPeaked && parkLineFlatlineTime >= 0) //flatline
                {
                    parkLineFlatlineTime--;
                    Graph.DataSource.AddPointToCategoryRealtime("Park Land", parkXValue, parkYValue, 1f); // each time we call AddPointToCategory 
                }
                else if (parkYValue - parkLandIncrease >= 0f && parkIsPeaked) //decrease graph
                {
                tempParkLevelYValue = Random.Range(parkYValue - parkLandIncrease, parkYValue); //want some variation to the graph
                //tempParkLevelYValue -= parkLandIncrease;
                    if (tempParkLevelYValue >= 0f)
                    {
                        parkYValue = tempParkLevelYValue;
                        Graph.DataSource.AddPointToCategoryRealtime("Park Land", parkXValue, parkYValue, 1f); // each time we call AddPointToCategory 
                    }

                }
       

            //oldParkYValue = parkYValue;
             }
             else if(!startParkGraph)
             {
                  Graph.DataSource.AddPointToCategoryRealtime("Park Land", parkXValue, parkYValue, 1f); // each time we call AddPointToCategory 

               }

    }
}
